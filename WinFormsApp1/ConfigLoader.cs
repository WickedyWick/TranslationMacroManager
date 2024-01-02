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
        public static Dictionary<string, string> langCodeMap = new Dictionary<string, string>()
        {
            { "af" , "Afrikaans" },
            { "sq" , "Albanian" },
            { "am" , "Amharic" },
            { "ar" , "Arabic" },
            { "hy" , "Armenian" },
            { "as" , "Assamese" },
            { "az" , "Azerbaijani (Latin)" },
            { "bn" , "Bangla" },
            { "ba" , "Bashkir" },
            { "eu" , "Basque" },
            { "bho" , "Bhojpuri" },
            { "brx" , "Bodo" },
            { "bs" , "Bosnian (Latin)" },
            { "bg" , "Bulgarian" },
            { "yue" , "Cantonese (Traditional)" },
            { "ca" , "Catalan" },
            { "lzh" , "Chinese (Literary)" },
            { "zh-Hans" , "Chinese Simplified" },
            { "zh-Hant" , "Chinese Traditional" },
            { "sn" , "chiShona" },
            { "hr" , "Croatian" },
            { "cs" , "Czech" },
            { "da" , "Danish" },
            { "prs" , "Dari" },
            { "dv" , "Divehi" },
            { "doi" , "Dogri" },
            { "nl" , "Dutch" },
            { "en" , "English" },
            { "et" , "Estonian" },
            { "fo" , "Faroese" },
            { "fj" , "Fijian" },
            { "fil" , "Filipino" },
            { "fi" , "Finnish" },
            { "fr" , "French" },
            { "fr-ca" , "French (Canada)" },
            { "gl" , "Galician" },
            { "ka" , "Georgian" },
            { "de" , "German" },
            { "el" , "Greek" },
            { "gu" , "Gujarati" },
            { "ht" , "Haitian Creole" },
            { "ha" , "Hausa" },
            { "he" , "Hebrew" },
            { "hi" , "Hindi" },
            { "mww" , "Hmong Daw (Latin)" },
            { "hu" , "Hungarian" },
            { "is" , "Icelandic" },
            { "ig" , "Igbo" },
            { "id" , "Indonesian" },
            { "ikt" , "Inuinnaqtun" },
            { "iu" , "Inuktitut" },
            { "iu-Latn" , "Inuktitut (Latin)" },
            { "ga" , "Irish" },
            { "it" , "Italian" },
            { "ja" , "Japanese" },
            { "kn" , "Kannada" },
            { "ks" , "Kashmiri" },
            { "kk" , "Kazakh" },
            { "km" , "Khmer" },
            { "rw" , "Kinyarwanda" },
            { "tlh-Latn" , "Klingon" },
            { "tlh-Piqd" , "Klingon (plqaD)" },
            { "gom" , "Konkani" },
            { "ko" , "Korean" },
            { "ku" , "Kurdish (Central)" },
            { "kmr" , "Kurdish (Northern)" },
            { "ky" , "Kyrgyz (Cyrillic)" },
            { "lo" , "Lao" },
            { "lv" , "Latvian" },
            { "lt" , "Lithuanian" },
            { "ln" , "Lingala" },
            { "dsb" , "Lower Sorbian" },
            { "lug" , "Luganda" },
            { "mk" , "Macedonian" },
            { "mai" , "Maithili" },
            { "mg" , "Malagasy" },
            { "ms" , "Malay (Latin)" },
            { "ml" , "Malayalam" },
            { "mt" , "Maltese" },
            { "mi" , "Maori" },
            { "mr" , "Marathi" },
            { "mn-Cyrl" , "Mongolian (Cyrillic)" },
            { "mn-Mong" , "Mongolian (Traditional)" },
            { "my" , "Myanmar" },
            { "ne" , "Nepali" },
            { "nb" , "Norwegian" },
            { "nya" , "Nyanja" },
            { "or" , "Odia" },
            { "ps" , "Pashto" },
            { "fa" , "Persian" },
            { "pl" , "Polish" },
            { "pt" , "Portuguese (Brazil)" },
            { "pt-pt" , "Portuguese (Portugal)" },
            { "pa" , "Punjabi" },
            { "otq" , "Queretaro Otomi" },
            { "ro" , "Romanian" },
            { "run" , "Rundi" },
            { "ru" , "Russian" },
            { "sm" , "Samoan (Latin)" },
            { "sr-Cyrl" , "Serbian (Cyrillic)" },
            { "sr-Latn" , "Serbian (Latin)" },
            { "st" , "Sesotho" },
            { "nso" , "Sesotho sa Leboa" },
            { "tn" , "Setswana" },
            { "sd" , "Sindhi" },
            { "si" , "Sinhala" },
            { "sk" , "Slovak" },
            { "sl" , "Slovenian" },
            { "so" , "Somali (Arabic)" },
            { "es" , "Spanish" },
            { "sw" , "Swahili (Latin)" },
            { "sv" , "Swedish" },
            { "ty" , "Tahitian" },
            { "ta" , "Tamil" },
            { "tt" , "Tatar (Latin)" },
            { "te" , "Telugu" },
            { "th" , "Thai" },
            { "bo" , "Tibetan" },
            { "ti" , "Tigrinya" },
            { "to" , "Tongan" },
            { "tr" , "Turkish" },
            { "tk" , "Turkmen (Latin)" },
            { "uk" , "Ukrainian" },
            { "hsb" , "Upper Sorbian" },
            { "ur" , "Urdu" },
            { "ug" , "Uyghur (Arabic)" },
            { "uz" , "Uzbek (Latin)" },
            { "vi" , "Vietnamese" },
            { "cy" , "Welsh" },
            { "xh" , "Xhosa" },
            { "yo" , "Yoruba" },
            { "yua" , "Yucatec Maya" },
            { "zu" , "Zulu" },
        };
        public static void LoadConfig()
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
                    return;
                }
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
                        return;
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
                            Config.Location = val;
                            break;
                        case "apikey":
                            Config.ApiKey = val;
                            break;
                        case "endpoint":
                            Config.Endpoint = val;
                            break;
                        default:
                            break;
                    }
                    line = sr.ReadLine();
                }
                bool correctlyLoaded = true;
                StringBuilder sb = new StringBuilder("Error during loading config. Missing fields: ");
                if (string.IsNullOrEmpty(Config.ApiKey))
                {
                    correctlyLoaded = false;
                    sb.Append("ApiKey, ");
                }
                if (string.IsNullOrEmpty(Config.Endpoint))
                {
                    correctlyLoaded = false;
                    sb.Append("Endpoint, ");
                }
                if (string.IsNullOrEmpty(Config.Location))
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

                return;
                
            } catch (Exception ex)
            {
                string msg = ex switch
                {
                    (FileNotFoundException or DirectoryNotFoundException) => "Settings file missing! Make sure to settings.txt file in root folder!",
                    _ => "Error while reading settings! Please make sure settings.txt is setup correctly!"
                };
                MessageBox.Show(msg, "Error during reading settings file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(Environment.ExitCode);
                return;
            }
            
        }
        public static void SetupComboBoxesValues(ComboBox from, ComboBox to)
        {
            string[] vals = langCodeMap.Values.ToArray();
            from.Items.AddRange(vals);
            to.Items.AddRange(vals);
        }
    }
    public static class Config
    {
        public static string Location { get; set; }
        public static string Endpoint { get; set; }
        public static string ApiKey { get; set; }
        public static string FromLangCode { get; set; }
        public static string ToLangCode { get; set; }
    }
    
    public enum ComboBoxType
    {
        FROM,
        TO,
    }
}
