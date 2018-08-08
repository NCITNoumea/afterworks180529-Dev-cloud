using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Afterworks.HappyFace.Infrastructure.Repositories;
using MS.Afterworks.HappyFace.Web.Services;
using MS.Afterworks.HappyFace.Web.ViewModels;

namespace MS.Afterworks.HappyFace.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmileRepository _repository;

        private readonly ITextAnalyticsService _textAnalyzeService;

        public HomeController(ISmileRepository repository, ITextAnalyticsService textAnalyzeService)
        {
            _repository = repository;
            _textAnalyzeService = textAnalyzeService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new SmileCountViewModel()
                {
                    SmileUpCount = await _repository.CountSmileUp(),
                    SmileDownCount = await _repository.CountSmileDown()
                };
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Smile(SmileCountViewModel model)
        {
            model.Smile.IsHappy = true;
            return await ProcessSmileResult(model);
        }

        public async Task<IActionResult> UnhappySmile(SmileCountViewModel model)
        {
            model.Smile.IsHappy = false;
            return await ProcessSmileResult(model);
        }

        private async Task<IActionResult> ProcessSmileResult(SmileCountViewModel model)
        {
            model.Smile.IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (!await _repository.AddSmileAsync(model.Smile))
                return View("Error");

            var commentAnalyzeresult = await _textAnalyzeService.AnalyzeTextAsync(model.Smile.Why);
            return View(commentAnalyzeresult);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
