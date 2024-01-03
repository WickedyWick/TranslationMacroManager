using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Actions
    {
        public static bool allowshowdisplay = false;
        public static bool ShowKeybinds(Form f)
        {
            allowshowdisplay = true;
            f.Visible = !f.Visible;
            return true;
        }

        public async static Task<bool> TranslateAndPaste()
        {
            string text = Clipboard.GetText();
            if (text == string.Empty)
                return false;
            string translated = await APIHelper.Translate(text);
            if (translated == string.Empty)
                return false;
            Clipboard.SetText(translated);
            SendKeys.Send("^{v}");
            return true;
        }

        public static bool PastePreset(Keys k)
        {
            // CTRL hotkeys are used onnly for printing characters
            string textToSet = Constants.keyCTRLDict[k].Chinese;
            Clipboard.SetText(textToSet);

            // Simulate CTRL+V
            SendKeys.Send("^{v}");
            return true;
        }

        public static async Task<bool> Test()
        {
            SendKeys.SendWait("^{a}");
            SendKeys.SendWait("^{c}");
            string text = Clipboard.GetText();
            if (string.IsNullOrEmpty(text))
                return false;
            string? translated = await APIHelper.Translate(text);
            if (string.IsNullOrEmpty(translated)) 
                return false;
            Clipboard.SetText(translated);
            SendKeys.SendWait("^{v}");
            return true;
        }


    }
}
