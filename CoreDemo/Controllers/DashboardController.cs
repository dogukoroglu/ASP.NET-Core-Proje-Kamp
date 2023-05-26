using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			Context c = new Context();
			var userName = User.Identity.Name;
			var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
			var writterid = c.Writters.Where(x => x.WritterMail == userMail).Select(y=>y.WritterID).FirstOrDefault();

			ViewBag.v1 = c.Blogs.Count().ToString();
			ViewBag.v2 = c.Blogs.Where(x => x.WritterID == writterid).Count();
			ViewBag.v3 = c.Categories.Count();
			return View();
		}
	}
}
