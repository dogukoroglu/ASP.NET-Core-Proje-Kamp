using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminMessageController : Controller
	{
		Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
		Context c = new Context();

		public IActionResult Inbox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writterId = c.Writters.Where(x => x.WritterMail == usermail).Select(y => y.WritterID).FirstOrDefault();
			var values = message2Manager.GetInboxListByWritter(writterId);
			return View(values);
		}

		public IActionResult Sendbox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writterId = c.Writters.Where(x => x.WritterMail == usermail).Select(y => y.WritterID).FirstOrDefault();
			var values = message2Manager.GetSendBoxListByWritter(writterId);
			return View(values);
		}

		//[HttpGet]
		//public IActionResult ComposeMessage()
		//{
		//	return View();
		//}

		//[HttpPost]
		//public IActionResult ComposeMessage(Message2 p)
		//{

		//	var username = User.Identity.Name;
		//	var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
		//	var writterId = c.Writters.Where(x => x.WritterMail == usermail).Select(y => y.WritterID).FirstOrDefault();
		//	p.SenderID = writterId;
		//	p.ReceiverID = 2;
		//	p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
		//	p.MessageStatus = true;
		//	message2Manager.TAdd(p);
		//	return RedirectToAction("Sendbox");
		//}

		[HttpGet]
		public async Task<IActionResult> ComposeMessage() //Admin paneli yeni mesaj yazma
		{

			List<SelectListItem> receiverUsers = (from x in await GetUsersAsync()
												  select new SelectListItem
												  {
													  Text = x.NameSurname.ToString(),
													  Value = x.Id.ToString()

												  }).ToList();
			ViewBag.Receiver = receiverUsers;
			return View();
		}

		[HttpPost]
		public IActionResult ComposeMessage(Message2 message2)
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writters.Where(x => x.WritterMail == usermail).Select(y => y.WritterID).FirstOrDefault();

			message2.SenderID = writerID;
			message2.MessageStatus = true;
			message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			message2Manager.TAdd(message2);
			return RedirectToAction("Sendbox");
		}

		public async Task<List<AppUser>> GetUsersAsync()
		{
			using (var c = new Context())
			{
				return await c.Users.ToListAsync();
			}
		}
	}
}
