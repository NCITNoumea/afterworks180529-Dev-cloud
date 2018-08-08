using System.Threading.Tasks;
using MS.Afterworks.HappyFace.Core.Models;

namespace MS.Afterworks.HappyFace.Web.Services
{
    public interface ITextAnalyticsService
    {
        Task<TextAnalyticsResult> AnalyzeTextAsync(string text);
    }
}
