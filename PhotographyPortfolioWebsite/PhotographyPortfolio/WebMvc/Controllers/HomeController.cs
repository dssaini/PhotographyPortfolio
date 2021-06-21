using Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Models;

namespace WebMvc.Controllers
{
    [Route("")]
    
    public class HomeController : Controller
    {
        private readonly IWebApiService _webApiService;
        public HomeController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        //[Route("Home/Index")]
        //[Route("Home")]
        [Route("")]
        [Route("Home")]
        //[Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            var getDashoard = await _webApiService.GetAsync<DashboardViewModel>
                (ApiConstants.WebConstants.getDashboard);
            if (getDashoard.StatusCode == 200)
            {
                return View(getDashoard);
            }
            return View(model);
        }
        [Route("About")]
        public IActionResult AboutTheArtist()
        {
            return View();
        }
        [Route("Portfolio")]
        public IActionResult Portfolio()
        {
            return View();
        }
        [Route("Blog")]
        public IActionResult Blog()
        {
            return View();
        }
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
