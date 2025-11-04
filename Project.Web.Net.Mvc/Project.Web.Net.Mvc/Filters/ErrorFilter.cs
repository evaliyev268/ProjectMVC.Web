using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project.Web.Net.Mvc.Data;
using Project.Web.Net.Mvc.Models;

namespace Project.Web.Net.Mvc.Filters
{

    public class ErrorFilter : ActionFilterAttribute 
    {
        private readonly AppDbContext _context;

        public ErrorFilter(AppDbContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idValue=context.ActionArguments.Values.First();

            var idFdb = (int)idValue;

            var hasProduct = _context.Contents.Any(x => x.Id == idFdb);

            if (!hasProduct)
            {
                context.Result = new RedirectToActionResult("Error", "Home", new ErrorViewModel() {Errors=new List<string>() {$"There is no content founded has this id:{idFdb}  id"} });
            }
        }
    }
}
