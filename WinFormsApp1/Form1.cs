
using System;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private KeyHandler ghk;
        public Form1()
        {
            InitializeComponent();
            ghk = new KeyHandler(this);
            ghk.RegisterAllHotKeys();
            notifyIcon.Text = "Macro Manager";
            notifyIcon.Visible = true;
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("Exit", null, SystemTrayExitClick));
            ConfigManager.SetupComboBoxesValues(ddlFrom, ddlTo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<Keys, Word> kvp in Constants.keyCTRLDict)
            {
                sb.AppendLine($"CTRL + {kvp.Key} = {kvp.Value.English}");
            }
            txbMain.Text = sb.ToString();
            this.Visible = false;
        }
        private async void HandleHotKey(int hashCode)
        {
            bool _ = hashCode switch
            {
                > 2000 => await HandleALT(hashCode),
                (> 1000) and (< 2000) => await HandleCTRL(hashCode),
                _ => false
            };
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                int hash = m.WParam.GetHashCode();
                HandleHotKey(hash);
            }

            base.WndProc(ref m);
        }

        private async Task<bool> HandleALT(int hashCode)
        {
            Keys k = Constants.hashKeyDict[hashCode];

            // This is simpler and better
            bool _ = k switch
            {
                Keys.NumPad0 => Actions.ShowKeybinds(this),
                Keys.NumPad1 => await Actions.TranslateAndPaste(),
                _ => false
            };
            return true;
        }

        private async Task<bool> HandleCTRL(int hashCode)
        {
            // CTRL hotkeys are used onnly for printing characters
            Keys k = Constants.hashKeyDict[hashCode];
            if (k == Keys.NumPad0)
            {
                return await Actions.Test();
            }
            return Actions.PastePreset(k);
        }


        private void btnHide_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void SystemTrayExitClick(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(Actions.allowshowdisplay ? value : Actions.allowshowdisplay);
        }

        private void languageChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (ddlFrom.SelectedIndex == ddlTo.SelectedIndex)
            {
                MessageBox.Show("From and To languages can't be same!", "Error setting language!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (cb.Name == "ddlFrom")
                    ddlFrom.SelectedIndex = ddlFrom.FindStringExact(ConfigManager.langCodeMap[Config.FromLangCode]);
                else
                    ddlTo.SelectedIndex = ddlTo.FindStringExact(ConfigManager.langCodeMap[Config.ToLangCode]);
                return;
            }
            int iF = ddlFrom.SelectedIndex;
            int iT = ddlTo.SelectedIndex;
            if (iF > -1 && iT > -1)
            {
                string fromHuman = ddlFrom.Items[ddlFrom.SelectedIndex].ToString();
                string toHuman = ddlTo.Items[ddlTo.SelectedIndex].ToString();
                string fromCode = "";
                string toCode = "";
                // can make reversed dictionary or use this, set is small so perf wise doesn't matter
                foreach (KeyValuePair<string, string> kvp in ConfigManager.langCodeMap)
                {
                    if (kvp.Value == fromHuman)
                        fromCode = kvp.Key;
                    else if (kvp.Value == toHuman)
                        toCode = kvp.Key;
                }
                if (Config.RememberLanguages)
                {
                    ConfigManager.SaveLangugageToConfig(fromCode, toCode);
                }
                Config.FromLangCode = fromCode;
                Config.ToLangCode = toCode;
            }        
        }
    }
}