    using Microsoft.AspNetCore.Mvc;

namespace Praktika_Template.Areas.EternaAdmin.Controllers
{
    [Area("EternaAdmin")]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
