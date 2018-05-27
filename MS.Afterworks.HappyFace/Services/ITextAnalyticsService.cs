using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MS.Afterworks.HappyFace.Core.Models;

namespace MS.Afterworks.HappyFace.Services
{
    public interface ITextAnalyticsService
    {
        Task<TextAnalyticsResult> AnalyzeTextAsync(string text);
    }
}
