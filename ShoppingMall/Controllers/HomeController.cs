using System.Web.Mvc;

namespace ShoppingMall.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }
    }
}