using System.Diagnostics;
using System.Resources;
using MacroManager.Properties;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration
            CheckIfAPplicationAlreadyRunning();
            ConfigLoader.LoadConfig();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }

        static void CheckIfAPplicationAlreadyRunning()
        {
            int count = 0;
            foreach (Process process in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName))
            {
                var p = process;
                count++;
                if (count > 1)
                {
                    DialogResult dr = MessageBox.Show("Another MacroManager instance already running! You can only run one instance at the time!", "Instance already running!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            
        }
    }
}