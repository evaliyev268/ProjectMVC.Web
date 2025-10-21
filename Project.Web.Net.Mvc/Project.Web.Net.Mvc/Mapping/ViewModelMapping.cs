using AutoMapper;
using Project.Web.Net.Mvc.Models;
using Project.Web.Net.Mvc.ViewModels;

namespace Project.Web.Net.Mvc.Mapping
{
    public class ViewModelMapping :Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Content, ContentViewModel>().ReverseMap();
        }
    }

    
}
