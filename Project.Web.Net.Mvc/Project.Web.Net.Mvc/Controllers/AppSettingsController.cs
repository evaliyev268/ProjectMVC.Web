using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Net.Mvc.Controllers
{
    public class AppSettingsController : Controller
    {
        private readonly IConfiguration _configuration;
        public AppSettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [Route("")]
        public IActionResult Index()
        {
            TempData["Url"] = _configuration["Secret"];

            return RedirectToAction(nameof(DictionaryController.ContentsIndex),"Dictionary");
        }
    }
}
