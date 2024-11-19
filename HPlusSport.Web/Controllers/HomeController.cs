using System.Web.Mvc;

namespace HPlusSport.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Error
        public ActionResult Error()
        {
            return View();
        }
    }
}