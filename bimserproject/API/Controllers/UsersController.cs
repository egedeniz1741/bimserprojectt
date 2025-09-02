using Microsoft.AspNetCore.Mvc;

namespace bimserproject.API.Controllers
{
    public class UsersController : Controller
    {

       
        public IActionResult Index()
        {
            return View();
        }
    }
}
