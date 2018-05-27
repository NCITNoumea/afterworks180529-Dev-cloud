using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Data;
using app.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private HappyfaceDbContext _dbContext;

        public HomeController(HappyfaceDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            SmileCountViewModel model = new SmileCountViewModel();
            model.SmileUpCount = _dbContext.Smiles.Where(s => s.IsHappy).Count();
            model.SmileDownCount = _dbContext.Smiles.Where(s => !s.IsHappy).Count();
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Smile()
        {
            try
            {
                var smile = new Smile { IsHappy = true, Why = "",
                    IpAddress = this.Request.HttpContext.Connection.RemoteIpAddress.ToString()
                };
                _dbContext.Smiles.Add(smile);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

            return View();
        }

        public IActionResult UnhappySmile()
        {
            try
            {
                var smile = new Smile { IsHappy = false, Why = "",
                    IpAddress = this.Request.HttpContext.Connection.RemoteIpAddress.ToString() };
                _dbContext.Smiles.Add(smile);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
