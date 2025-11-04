using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Net.Mvc.Data;
using Project.Web.Net.Mvc.ViewModels;
using Project.Web.Net.Mvc.Models;
using Project.Web.Net.Mvc.Filters;
using System.Security.AccessControl;
using Microsoft.Extensions.FileProviders;

namespace Project.Web.Net.Mvc.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DictionaryController(AppDbContext context, IMapper mapper,IFileProvider fileProvider)
        {
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }

        
        [Route("")]
        [Route("/contentindex",Name="contentindex_route")]
        public IActionResult ContentsIndex()
        {
            var list = _mapper.Map<List<ContentViewModel>>(_context.Contents.ToList());
            return View(list);
        }

        [Route("/create", Name="contentcreate_route")]
        public IActionResult ContentCreate()
        {
           


            return View();
        }

        [Route("/save",Name ="contentsave_route")]
        [HttpPost]
        public IActionResult Save(ContentViewModel contentViewModel)
        {

            if (ModelState.IsValid)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var images = root.First(x => x.Name == "images");
                var path = Path.Combine(images.PhysicalPath, contentViewModel.Image.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                contentViewModel.Image.CopyTo(stream);

                var product = _mapper.Map<Models.Content>(contentViewModel);
                product.ImagePath = contentViewModel.Image.FileName;

                _context.Contents.Add(product);
                _context.SaveChanges();


                return RedirectToAction("ContentsIndex");
            }
            else
            {
                return RedirectToAction("ContentCreate");
            }

            
        }

         [ServiceFilter(typeof(ErrorFilter))]
        [Route("/contentdelete/{id}", Name = "contentdelete_route")]

        public IActionResult ContentDelete(int id)
        {
            
            _context.Contents.Remove(_context.Contents.Find(id));
            _context.SaveChanges();
            return RedirectToAction("ContentsIndex");
        }

        
    }
}
