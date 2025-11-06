namespace Project.Web.Net.Mvc.Models
{
    public class Content
    {
        public int? Id { get; set; }

        public string? Topic { get; set; }

        public string? Author { get; set; }

        public string? AuthorsOpinion { get; set; }

        public DateTime? Date { get; set; }

        public string? ImagePath { get; set; }

        public int? LikeCount { get; set; }

        public Category? Category { get; set; }

        public int? CategoryId { get; set; }
    }
}
