using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Net.Mvc.Data;
using Project.Web.Net.Mvc.ViewModels;

namespace Project.Web.Net.Mvc.Controllers
{
    public class DictionaryAjaxController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DictionaryAjaxController(IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("/ajaxindex",Name ="ajaxindex_route")]
        public IActionResult AjaxIndex()
        {

            return View();
        }


        [HttpGet]
        [Route("/ajaxlistcomments")]
        public IActionResult ListComments()
        {
            var visitor = _context.Visitors.ToList();
            var visitorViewModels = _mapper.Map<List<VisitorViewModel>>(visitor);

            return Json(visitorViewModels); 
            
        }



        [HttpPost]
        [Route("/ajaxsavecomments")]
        public IActionResult SaveComment(VisitorViewModel visitorViewModel)
        {
            var visitor = _mapper.Map<Models.Visitor>(visitorViewModel);

            _context.Visitors.Add(visitor);
            _context.SaveChanges();

            return Json(new { IsSuccess = "true" });

        }


        [Route("/deleteajax")]
        public IActionResult DeleteAll()
        {
            var list=_context.Visitors.OrderByDescending(x=>x.Id).ToList();
            _context.Visitors.RemoveRange(list);
            _context.SaveChanges();

            return RedirectToAction(nameof(DictionaryAjaxController.AjaxIndex));
        }

    }
}
