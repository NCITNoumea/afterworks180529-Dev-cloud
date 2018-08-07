using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Extensions.Logging;
using MS.Afterworks.HappyFace.Core.Models;
using MS.Afterworks.HappyFace.Web.Services.Cognitive;

namespace MS.Afterworks.HappyFace.Web.Services
{
    public class TextAnalyticsService : ITextAnalyticsService
    {
        readonly ILogger<TextAnalyticsService> _logger;

        public TextAnalyticsService(ILogger<TextAnalyticsService> logger)
        {
            _logger = logger;
        }

        public async Task<TextAnalyticsResult> AnalyzeTextAsync(string text)
        {
            try
            {
                // COGNITIVE SERVICE : client API REST
                ITextAnalyticsAPI client = new TextAnalyticsAPI(new ApiKeyServiceClientCredentials())
                {
                    AzureRegion = AzureRegions.Australiaeast
                };

                var result = new TextAnalyticsResult();

                // COGNITIVE SERVICE : Détection de la langue
                var resultLanguage = await client.DetectLanguageAsync(new BatchInput(
                        new List<Input>() { new Input("0", text) }));

                var l = resultLanguage.Documents[0].DetectedLanguages[0];
                result.Language = l.Name;
                result.LanguageIso = l.Iso6391Name;

                // COGNITIVE SERVICE : Détection des phrases clés
                var resultKeyPhrases = client.KeyPhrasesAsync(new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>() { new MultiLanguageInput(result.LanguageIso, "0", text) }));

                result.KeyPhrases = resultKeyPhrases.Result.Documents[0].KeyPhrases.ToArray();

                // COGNITIVE SERVICE : Détection du score de sentiment
                var resultSentiment = client.SentimentAsync(new MultiLanguageBatchInput(
                    new List<MultiLanguageInput>() { new MultiLanguageInput(result.LanguageIso, "0", text) }));

                result.ScoreSentiment = resultSentiment.Result.Documents[0].Score;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Text analyze : {ex.Message}");
                return null;
            }
        }
    }
}
