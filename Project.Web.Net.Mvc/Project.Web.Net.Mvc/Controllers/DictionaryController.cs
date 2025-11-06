using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Net.Mvc.Data;
using Project.Web.Net.Mvc.ViewModels;
using Project.Web.Net.Mvc.Models;
using Project.Web.Net.Mvc.Filters;
using System.Security.AccessControl;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Web.Net.Mvc.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DictionaryController(AppDbContext context, IMapper mapper, IFileProvider fileProvider)
        {
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }


        //[Route("")]
        [Route("/contentindex", Name = "contentindex_route")]
        public IActionResult ContentsIndex()
        {


            ViewBag.CookieBag = Request.Cookies["course-name"];


            var list = _mapper.Map<List<ContentViewModel>>(_context.Contents.ToList());

            ViewBag.UrlBag = TempData["Url"];


            foreach (var item in list)
            {
                var category = _context.Category.Find(item.CategoryId);
                item.Category = category;
            }
                return View(list);
            
        }
        [Route("/create", Name = "contentcreate_route")]
        public IActionResult ContentCreate()
        {
            var categories = _context.Category.ToList();

            ViewBag.CategoryList = new SelectList(categories,"Id","Name");
            

            return View();
        }

        [Route("/save", Name = "contentsave_route")]
        [HttpPost]
        public IActionResult Save(ContentViewModel contentViewModel)
        {

            if (ModelState.IsValid)
            {
                #region images root,stream and database saving
                //var root = _fileProvider.GetDirectoryContents("wwwroot");
                //var images = root.First(x => x.Name == "images");
                //var randomFileName = Guid.NewGuid() + Path.GetExtension(contentViewModel.Image.FileName);
                //var path = Path.Combine(images.PhysicalPath, randomFileName);
                //using var stream = new FileStream(path, FileMode.Create);
                //contentViewModel.Image.CopyTo(stream);

                //var product = _mapper.Map<Models.Content>(contentViewModel);
                //product.ImagePath = randomFileName;


                #endregion


                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var images = root.First(x => x.Name == "images");


                string? randomFileName = null;

                if (contentViewModel.Image != null && contentViewModel.Image.Length > 0)
                {
                    randomFileName = Guid.NewGuid() + Path.GetExtension(contentViewModel.Image.FileName);
                    var path = Path.Combine(images.PhysicalPath, randomFileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    contentViewModel.Image.CopyTo(stream);

                }

                var content = _mapper.Map<Models.Content>(contentViewModel);
                content.ImagePath = randomFileName;

               

                _context.Contents.Add(content);
                _context.SaveChanges();

                return RedirectToAction("ContentsIndex");
            }
            else
            {
                return RedirectToAction("Index", "Home");
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


        [Route("/contentupdate/{id}", Name ="contentupdate_route") ]
        public IActionResult ContextUpdate(int id)
        {

            var content = _context.Contents.Find(id);

            var categories = _context.Category.ToList();

            ViewBag.CategoryList = new SelectList(categories, "Id", "Name", content.CategoryId);

            return View(_mapper.Map<ContentViewModel>(content));
        }

        [Route("/contentupgrade", Name = "contentupgrade_route")]
        public IActionResult ContextUpgrade(ContentViewModel contentViewModel )
        {
            var root = _fileProvider.GetDirectoryContents("wwwroot");
            var images = root.First(x => x.Name == "images");
            var content = _mapper.Map<Models.Content>(contentViewModel);

            string? randomFileName = null;

            if (contentViewModel.Image != null && contentViewModel.Image.Length > 0)
            {
                randomFileName = Guid.NewGuid() + Path.GetExtension(contentViewModel.Image.FileName);
                var path = Path.Combine(images.PhysicalPath, randomFileName);

                using var stream = new FileStream(path, FileMode.Create);
                contentViewModel.Image.CopyTo(stream); 
                content.ImagePath = randomFileName;

            }
            



            _context.Contents.Update(content);
            _context.SaveChanges();


            return RedirectToAction("ContentsIndex");
        }

        [Route("/deleteall",Name ="deleteall_route")]
        public IActionResult DeleteAll()
        {
            var contents = _context.Contents.ToList();
            _context.Contents.RemoveRange(contents);
            _context.SaveChanges();


            return RedirectToAction("ContentsIndex");
        }
    }
}
