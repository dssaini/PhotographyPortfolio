using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Controllers
{
    [Route("")]
    
    public class HomeController : Controller
    {
        //[Route("Home/Index")]
        //[Route("Home")]
        [Route("")]
        [Route("Home")]
        //[Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
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
