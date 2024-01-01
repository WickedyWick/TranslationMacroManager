using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class TranslationDto
    {
        public TranslationData[] translations { get; set; }
    }

    public class TranslationData
    {
        public string text { get; set; }
        public string to { get; set; }
    }
}
