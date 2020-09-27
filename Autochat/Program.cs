using Autochat.Controls;
using Autochat.Models;
using GlobalHotKey;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YamlDotNet.Serialization;

namespace Autochat
{
    static class Program
    {
        static HotKeyGraphTraversalEngine engine;
        static PrintOnTransitionHandler printHandler;
        static PreviewHandler previewHandler;

        static ContentFileProcessor contentFileProcessor;
        static DefinitionFileProcessor definitionFileProcessor;
        static IDeserializer deserializer;

        static LocalPathResolver resolver = new LocalPathResolver();
        static ContentPrinter printer = new ContentPrinter();
        static PreviewData previewData = new PreviewData();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeEngineHotKeyEngine();
            StartForm();
        }

        static void InitializeEngineHotKeyEngine()
        {
            deserializer = new DeserializerBuilder().Build();
            contentFileProcessor = new ContentFileProcessor(resolver);
            definitionFileProcessor = new DefinitionFileProcessor(deserializer, resolver);
            printHandler = new PrintOnTransitionHandler(contentFileProcessor, printer);
            previewHandler = new PreviewHandler(previewData, 
                contentFileProcessor, 
                definitionFileProcessor);
            engine = BuildHotKeyGraphTraversalEngine();
            
            engine.OnTransitionTo += printHandler.PrintContent;
            engine.OnTransitionTo += previewHandler.UpdatePreviewData;
        }

        static HotKeyGraphTraversalEngine BuildHotKeyGraphTraversalEngine()
        {
            var perpetuals = new List<(HotKey, Action)>();
            perpetuals.Add((new HotKey(System.Windows.Input.Key.P, 
                System.Windows.Input.ModifierKeys.Control 
                    | System.Windows.Input.ModifierKeys.Alt),
                () => printHandler.PrintContent(engine.Current)));

            return new HotKeyGraphTraversalEngine(definitionFileProcessor, perpetuals);
        }

        static void StartForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(engine, resolver, previewData));
        }
    }
}
