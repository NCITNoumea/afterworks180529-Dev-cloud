using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Data;
using app.Models;
using MS.Afterworks.HappyFace.Repositories;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmileRepository _repository;

        public HomeController(ISmileRepository repository)
        {
            _repository = repository;
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
            model.Smile.IpAddress = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (await _repository.AddSmileAsync(model.Smile))
                return View();
            else
                return View("Error");
        }

        public async Task<IActionResult> UnhappySmile(SmileCountViewModel model)
        {
            model.Smile.IsHappy = false;
            model.Smile.IpAddress = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (await _repository.AddSmileAsync(model.Smile))
                return View();
            else
                return View("Error");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
