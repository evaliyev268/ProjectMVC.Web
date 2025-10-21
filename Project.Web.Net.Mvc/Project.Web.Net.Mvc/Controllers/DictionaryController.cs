using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Net.Mvc.Controllers
{
    public class DictionaryController : Controller
    {
        public IActionResult ContentsIndex()
        {
            return View();
        }

        public IActionResult ContentUpgrade()
        {
            return View();
        }


    }
}
