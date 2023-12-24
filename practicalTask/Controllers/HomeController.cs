using Microsoft.AspNetCore.Mvc;

namespace practicalTask.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
