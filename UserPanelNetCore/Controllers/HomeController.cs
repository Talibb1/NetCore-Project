using Microsoft.AspNetCore.Mvc;

namespace UserPanelNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
