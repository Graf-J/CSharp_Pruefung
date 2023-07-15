using Microsoft.AspNetCore.Mvc;

namespace BookWebApplication.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
