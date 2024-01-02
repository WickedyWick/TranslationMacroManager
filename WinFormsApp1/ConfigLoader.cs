using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class ConfigLoader
    {
        public static Config LoadConfig()
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "settings.txt");
                using StreamReader sr = new StreamReader(path);
                string? line = sr.ReadLine();
                if (line == null)
                {
                    MessageBox.Show("Settings file empty!", "Error during reading settings file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                    return new Config();
                }
                Config cfg = new Config();
                while (line != null)
                {
                    if (line == "" || line == "\n\r" || line == "\r\n")
                    {
                        line = sr.ReadLine();
                        continue;
                    }

                    string[] args = line.Trim().Split('=');
                    if (args.Length != 2)
                    {
                        MessageBox.Show("Incorect settings file format, refer to README!", "Error during reading settings file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(Environment.ExitCode);
                        return cfg;
                    }

                    string key = args[0].Trim().ToLower();
                    string val = args[1].Trim();
                    if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(val))
                    {
                        line = sr.ReadLine();
                        continue;
                    }

                    switch (key)
                    {
                        case "location":
                            cfg.Location = val;
                            break;
                        case "apikey":
                            cfg.ApiKey = val;
                            break;
                        case "endpoint":
                            cfg.Endpoint = val;
                            break;
                        default:
                            break;
                    }
                    line = sr.ReadLine();
                }
                bool correctlyLoaded = true;
                StringBuilder sb = new StringBuilder("Error during loading config. Missing fields: ");
                if (string.IsNullOrEmpty(cfg.ApiKey))
                {
                    correctlyLoaded = false;
                    sb.Append("ApiKey, ");
                }
                if (string.IsNullOrEmpty(cfg.Endpoint))
                {
                    correctlyLoaded = false;
                    sb.Append("Endpoint, ");
                }
                if (string.IsNullOrEmpty(cfg.Location))
                {
                    correctlyLoaded = false;
                    sb.Append("Location.\n");
                }
                
                if (!correctlyLoaded)
                {
                    sb.Append("Please refer to README or settings.example.txt file");
                    MessageBox.Show(sb.ToString(), "Error during reading settings file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }

                return cfg;
                
            } catch (Exception ex)
            {
                string msg = ex switch
                {
                    (FileNotFoundException or DirectoryNotFoundException) => "Settings file missing! Make sure to settings.txt file in root folder!",
                    _ => "Error while reading settings! Please make sure settings.txt is setup correctly!"
                };
                MessageBox.Show(msg, "Error during reading settings file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(Environment.ExitCode);
                return new Config();
            }
            
        }
    }
    public class Config
    {
        public string Location { get; set; }
        public string Endpoint { get; set; }
        public string ApiKey { get; set; }
    }
}
