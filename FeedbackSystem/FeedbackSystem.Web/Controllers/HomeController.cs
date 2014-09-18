namespace FeedbackSystem.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.Http.Cors;

    [EnableCors("*", "*", "*")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
