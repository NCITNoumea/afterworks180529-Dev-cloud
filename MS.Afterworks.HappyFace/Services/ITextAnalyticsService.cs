using MS.Afterworks.HappyFace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Afterworks.HappyFace.Services
{
    public interface ITextAnalyticsService
    {
        Task<TextAnalyticsResult> AnalyzeTextAsync(string text);
    }
}
