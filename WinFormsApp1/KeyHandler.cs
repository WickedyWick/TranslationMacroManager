using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class KeyHandler
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private IntPtr hWnd;

        public KeyHandler(Form form)
        {
            this.hWnd = form.Handle;
        }

        public int GetHashCode(int key)
        {
            return key % hWnd.ToInt32();
        }

        public void RegisterAllHotKeys()
        {
            int hashCode = 0;
            int key = 0;
            // Registtering CTRL keys
            foreach(Keys k in Constants.keyCTRLDict.Keys)
            {
                key = (int)k;
                hashCode = (int)Offset.CTRL + GetHashCode(key);
                Register(hashCode, key, Prefix.CTRL);
                Constants.hashKeyDict.Add(hashCode, k);
            }

            // Registering ALT keys
            foreach(Keys k in Constants.keyALTDict.Keys)
            {
                key = (int)k;
                hashCode = (int)Offset.ALT + GetHashCode(key);
                Register(hashCode, key, Prefix.ALT);
                Constants.hashKeyDict.Add(hashCode, k);
            }

        }
        public bool Register(int hashCode, int key, Prefix prefix)
        {
            // 0x0002 is fsModifier value for CTRL so it must be pressed with the key for hotkey to activate
            return RegisterHotKey(hWnd, hashCode, (int)prefix, key);
        }

        public bool Unregister(int hashCode)
        {
            return UnregisterHotKey(hWnd, hashCode);
        }

    }
}
