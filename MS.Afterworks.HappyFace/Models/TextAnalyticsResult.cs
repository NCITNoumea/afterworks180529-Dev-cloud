using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Afterworks.HappyFace.Models
{
    public class TextAnalyticsResult
    {
        public string Language { get; set; }

        public string LanguageIso { get; set; }

        public string[] KeyPhrases { get; set; }

        public double? ScoreSentiment { get; set; }
    }
}
