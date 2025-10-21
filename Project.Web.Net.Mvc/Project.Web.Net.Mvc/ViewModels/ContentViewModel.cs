namespace Project.Web.Net.Mvc.ViewModels
{
    public class ContentViewModel
    {
        public int? Id { get; set; }

        public string? Topic { get; set; }

        public string? Author { get; set; }

        public string? AuthorsOpinion { get; set; }

        public DateTime? Date { get; set; }



    }

    public class ContentViewModelList
    {
         public List<ContentViewModel> ContentList { get; set; }
    }

}
