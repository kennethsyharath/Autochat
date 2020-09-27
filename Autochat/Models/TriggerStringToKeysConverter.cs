using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Autochat.Models
{
    static class TriggerStringToKeysConverter
    {
        public static (Key baseKey, ModifierKeys modKeys) Convert(string triggerString)
        {
            var tokens = triggerString.Split('+');

            Key retKey = Key.None;
            ModifierKeys retModKeys = ModifierKeys.None;

            foreach (var token in tokens)
            {
                if (Enum.TryParse<Keys>(token, out var result))
                {
                    if (!IsModifier(result))
                        retKey = KeyInterop.KeyFromVirtualKey((int)result);
                    else
                        retModKeys |= AsModifier(result);
                }
            }
            
            return (retKey, retModKeys);
        }

        static bool IsModifier(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Control:
                case Keys.Shift:
                case Keys.Alt:
                    return true;
                default: return false;
            }
        }

        static ModifierKeys AsModifier(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Control:
                    return ModifierKeys.Control;
                case Keys.Alt:
                    return ModifierKeys.Alt;
                case Keys.Shift:
                    return ModifierKeys.Shift;
                default:
                    return ModifierKeys.None;
            }
        }
    }
}
