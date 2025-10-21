using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Net.Mvc.Data;
using Project.Web.Net.Mvc.ViewModels;
using System.Collections.Generic;

namespace Project.Web.Net.Mvc.Views.Shared.ViewComponents
{
    public class DictionaryViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public DictionaryViewComponent(AppDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

            if (!_context.Contents.Any())
            {
                _context.Contents.Add(new() { Topic = "Developer", Author = "Elvin", AuthorsOpinion = "Dev s work for find real time projects", Date = DateTime.Now });
                _context.SaveChanges();


            }
        }

     

        public async Task<IViewComponentResult> InvokeAsync(int type=0)
        {
            if (type==0) {
                var list = _mapper.Map<List<ContentViewModel>>(_context.Contents.ToList());
                return View("Contents", list);
            }
            else
            {
                return View("ContentsCreate");
            }
            
        }
    }
}
