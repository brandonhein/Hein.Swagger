using Microsoft.AspNetCore.Mvc;

namespace Hein.Swagger.Sample.Contorllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
