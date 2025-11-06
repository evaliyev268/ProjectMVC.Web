using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Net.Mvc.Filters;
using Project.Web.Net.Mvc.Models;

namespace Project.Web.Net.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[CacheResourceFilter]
        [Route("/homeindex", Name = "homeindex_route")]
        public IActionResult Index()
        {
            // throw new Exception("There is an Error Occupied");

            //return RedirectToAction("ContentsIndex","Dictionary");

            Response.Cookies.Append("course-name", "diffrential-equations");
            
            return View();
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/error", Name = "error_route")]
        public IActionResult Error(ErrorViewModel theerror)
        {
            theerror.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            return View(theerror);
        }
    }
}
