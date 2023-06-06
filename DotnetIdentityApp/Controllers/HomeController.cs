using Microsoft.AspNetCore.Mvc;

namespace DotnetIdentityApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult TitleAccessUpdate(int? Id)
        {
            return Json($"Access Id {Id} has been updated!");
        }
    }
}
