using Autochat.Models;
using GlobalHotKey;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Configuration;
using System.Windows.Input;

namespace Autochat.Controls
{
    public class HotKeyGraphTraversalEngine
    {
        DefinitionFileProcessor _processor;

        HotKeyManager hotKeyManager = new HotKeyManager();
        HashSet<HotKey> activeHotKeys = new HashSet<HotKey>(); 
        Dictionary<HotKey, Action> hotKeyActions = new Dictionary<HotKey, Action>();
        Dictionary<HotKey, Action> perpetualHotKeys = new Dictionary<HotKey, Action>();

        public Action<TransitionNode> OnTransitionTo;

        TransitionNode _current;
        public TransitionNode Current 
        {
            get => _current;
            protected set => TransitionTo(value);
        }

        public HotKeyGraphTraversalEngine(DefinitionFileProcessor processor, 
            List<(HotKey hk, Action a)> perpetuals = default)
        {
            _processor = processor;

            hotKeyManager.KeyPressed += HandleKeyPressed;

            foreach (var hotKey in perpetuals)
            {
                (HotKey hk, Action a) = hotKey;
                perpetualHotKeys[hk] = a;
            }
        }

        ~HotKeyGraphTraversalEngine()
        {
            hotKeyManager.KeyPressed -= HandleKeyPressed;
        }

        public HotKeyGraphTraversalEngine(DefinitionFileProcessor processor, string startDefinitionFilePath)
        {
            _processor = processor;
            Current = _processor.ProcessDefinitionFile(startDefinitionFilePath);
        }

        public void InitializeEngineTo(string startDefinitionFilePath)
        {
            Current = _processor.ProcessDefinitionFile(startDefinitionFilePath);
        }

        void TransitionTo(TransitionNode arg)
        {
            _current = arg; //Cache the current node;
            ClearHotKeys();
            InitializePerpetualHotKeys();
            InitializeTransitionHotKeys();
            OnTransitionTo?.Invoke(arg);
        }

        void InitializePerpetualHotKeys()
        {
            foreach (var hk in perpetualHotKeys.Keys)
            {
                Debug.WriteLine("Registering perpetual");
                RegisterHotKey(hk, perpetualHotKeys[hk]);
            }
        }

        void InitializeTransitionHotKeys()
        {
            foreach (var t in _current.Transitions)
            {
                (Key baseKey, ModifierKeys modKeys) = TriggerStringToKeysConverter.Convert(t.Trigger);
                var hotKey = new HotKey(baseKey, modKeys);

                RegisterHotKey(hotKey, () => TransitionTo(t.DefFilePath));
            }

        }

        void RegisterHotKey(HotKey hk, Action action)
        {
            Debug.WriteLine($"Registering hk ({hk.Key} + {hk.Modifiers})");

            activeHotKeys.Add(hk);
            hotKeyManager.Register(hk);
            hotKeyActions[hk] = action;
        }

        void ClearHotKeys()
        {
            foreach (var key in activeHotKeys)
                hotKeyManager.Unregister(key);
            activeHotKeys.Clear();
            hotKeyActions.Clear();
        }

        void TransitionTo(string targetDefFile)
        {
            Debug.WriteLine($"Attempting to transition to {targetDefFile}");
            var targetNode = _processor.ProcessDefinitionFile(targetDefFile);
            TransitionTo(targetNode);
        }

        void HandleKeyPressed(object sender, KeyPressedEventArgs args)
        {
            hotKeyActions[args.HotKey]?.Invoke();
        }
    }
}
