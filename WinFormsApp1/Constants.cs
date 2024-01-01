using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class Constants
    {
        public const int WM_HOTKEY_MSG_ID = 0x0312;
        // Predefined CTRL functionalities
        public static Dictionary<Keys, Word> keyCTRLDict = new Dictionary<Keys, Word>()
        {
            { Keys.NumPad0, new Word { Chinese ="hhi", English = "hiiii"} },
            // Hi
            { Keys.NumPad1, new Word { Chinese = "嗨", English = "Hi" } },
            // Hi/Hello
            { Keys.NumPad2, new Word { Chinese = "你好", English = "Hi/Hello" } },
            // Hahaha
            { Keys.NumPad3,  new Word { Chinese = "哈哈哈", English = "Hahaha" } },
            // Yes
            { Keys.NumPad4, new Word { Chinese = "是的", English = "Yes" } },
            // OK
            { Keys.NumPad5, new Word { Chinese = "好的", English = "OK" } },
            // No
            { Keys.NumPad6, new Word { Chinese = "不", English = "No" } },
            // Thanks
            { Keys.NumPad7, new Word { Chinese = "謝謝", English = "Thanks" } },
            // Understood
            { Keys.NumPad8, new Word { Chinese = "明白了", English = "Understood" } },
            // Goodbye
            { Keys.NumPad9, new Word { Chinese = "再见", English = "Goodbye" } }
        };

        // Predefined ALT functionalities
        // Ok actually this concept isn't required and might be over complicated, but will keep it since its interesting
        // for future reference
        // Ideally it would be HashSet<Keys>
        // here you can register keybind and in form.cs you need to call it
        public static Dictionary<Keys, Delegate> keyALTDict = new Dictionary<Keys, Delegate>()
        {
            { Keys.NumPad0, new Func<Form, bool>(Actions.ShowKeybinds)},
            { Keys.NumPad1, new Func<Task<bool>> (Actions.TranslateAndPaste)},
            { Keys.NumPad2, new Func<Task<bool>> (Actions.Test)}
        };

        // populated on runtime
        // This is dict has hashcode for key and key associcated with it
        // 1000-2000 are CTRL binds
        // 2000-3000 are ALT binds
        public static Dictionary<int, Keys> hashKeyDict = new Dictionary<int, Keys>();
    }

    public enum Prefix
    {
        CTRL = 0x0002,
        ALT = 0x0001
    }
    public enum Offset
    {
        CTRL = 1000,
        ALT = 2000
    }

}
