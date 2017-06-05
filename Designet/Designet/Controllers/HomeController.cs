using System.Web.Mvc;

namespace Designet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page Test";

            return View();
        }
    }
}
