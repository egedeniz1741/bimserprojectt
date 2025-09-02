using Microsoft.AspNetCore.Mvc;

namespace bimserproject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
