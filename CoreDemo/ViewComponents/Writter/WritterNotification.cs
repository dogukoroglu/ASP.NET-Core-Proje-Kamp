using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writter
{
	public class WritterNotification : ViewComponent
	{
		NotificationManager nm = new NotificationManager(new EfNotificationRepository());
		public IViewComponentResult Invoke()
		{
			var values = nm.GetList();
			return View(values);
		}
	}
}
