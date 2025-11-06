using System.ComponentModel.DataAnnotations;

namespace Project.Web.Net.Mvc.Models
{
    public class Category
    {

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public List<Content>? Contents { get; set; }
    }

   
}
