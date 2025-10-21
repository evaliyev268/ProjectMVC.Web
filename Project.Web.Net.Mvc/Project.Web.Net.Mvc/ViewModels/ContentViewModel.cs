using System.ComponentModel.DataAnnotations;

namespace Project.Web.Net.Mvc.ViewModels
{
    public class ContentViewModel
    {
        
        public int? Id { get; set; }

        [Required]
        public string? Topic { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public string? AuthorsOpinion { get; set; }

        [Required]
        public DateTime? Date { get; set; }



    }

    public class ContentViewModelList
    {
         public List<ContentViewModel> ContentList { get; set; }
    }

}
