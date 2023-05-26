using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	public class MessageController : Controller
	{
		Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
		Context c = new Context();
		public IActionResult InBox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writterId = c.Writters.Where(x => x.WritterMail == usermail).Select(y => y.WritterID).FirstOrDefault();
			var values = message2Manager.GetInboxListByWritter(writterId);
			return View(values);
		}

		public IActionResult SendBox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writterId = c.Writters.Where(x => x.WritterMail == usermail).Select(y => y.WritterID).FirstOrDefault();
			var values = message2Manager.GetSendBoxListByWritter(writterId);
			return View(values);
		}

		public IActionResult MessageDetails(int id)
		{
			var value = message2Manager.TGetById(id);
			return View(value);
		}

		[HttpGet]
		public IActionResult SendMessage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendMessage(Message2 p)
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writterId = c.Writters.Where(x => x.WritterMail == usermail).Select(y => y.WritterID).FirstOrDefault();
			p.SenderID = writterId;
			p.ReceiverID = 2;
			p.MessageStatus = true;
			p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			message2Manager.TAdd(p);
			return RedirectToAction("InBox");
		}
	}
}
