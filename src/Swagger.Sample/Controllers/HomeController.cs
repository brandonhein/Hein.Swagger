using Microsoft.AspNetCore.Mvc;

namespace Hein.Swagger.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
