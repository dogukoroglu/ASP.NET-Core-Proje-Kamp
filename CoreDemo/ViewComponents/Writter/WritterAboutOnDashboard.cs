using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writter
{
	public class WritterAboutOnDashboard:ViewComponent
	{
		WritterManager wm = new WritterManager(new EfWritterRepository());

		Context c = new Context();

		public IViewComponentResult Invoke()
		{
			var userName = User.Identity.Name;
			ViewBag.veri = userName;
			var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault(); 
			var writerId = c.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterID).FirstOrDefault();
			var values = wm.GetWritterByID(writerId);
			return View(values);
		}
	}
}
