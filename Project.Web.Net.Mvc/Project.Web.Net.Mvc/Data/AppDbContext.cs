
using Project.Web.Net.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Project.Web.Net.Mvc.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Content> Contents { get; set; }

    }
}
