using Microsoft.AspNetCore.Mvc;

namespace ERPAdmin.Services.Contractors.API.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger/ui");
        }
    }
}
