using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Net.Mvc.Data;
using Project.Web.Net.Mvc.ViewModels;
using Project.Web.Net.Mvc.Models;

namespace Project.Web.Net.Mvc.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DictionaryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult ContentsIndex()
        {
            return View();
        }

        public IActionResult ContentCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(ContentViewModel contentViewModel)
        {

            if (ModelState.IsValid)
            {
                _context.Contents.Add(_mapper.Map<Models.Content>(contentViewModel));
                _context.SaveChanges();


                return RedirectToAction("ContentsIndex");
            }
            else
            {
                return RedirectToAction("ContentCreate");
            }

            
        }

        
        public IActionResult ContentDelete(int id)
        {
            
            _context.Contents.Remove(_context.Contents.Find(id));
            _context.SaveChanges();
            return RedirectToAction("ContentsIndex");
        }
    }
}
