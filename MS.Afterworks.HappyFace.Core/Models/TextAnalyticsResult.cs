namespace MS.Afterworks.HappyFace.Core.Models
{
    public class TextAnalyticsResult
    {
        public string Language { get; set; }

        public string LanguageIso { get; set; }

        public string[] KeyPhrases { get; set; }

        public double? ScoreSentiment { get; set; }
    }
}
