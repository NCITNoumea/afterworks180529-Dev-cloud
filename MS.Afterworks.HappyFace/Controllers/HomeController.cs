using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using app.Models;
using MS.Afterworks.HappyFace.Services;
using MS.Afterworks.HappyFace.Core.Infrastructure.Repositories;

namespace WebApplication.Controllers
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
            SmileCountViewModel model = new SmileCountViewModel()
            {
                SmileUpCount = await _repository.CountSmileUp(),
                SmileDownCount = await _repository.CountSmileDown()
            };
            return View(model);
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
            if (await _repository.AddSmileAsync(model.Smile))
            {
                // COGNITIVE SERVICES : Analyse du texte
                var commentAnalyzeresult = await _textAnalyzeService.AnalyzeTextAsync(model.Smile.Why);
                return View(commentAnalyzeresult);
            }
            else
                return View("Error");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
