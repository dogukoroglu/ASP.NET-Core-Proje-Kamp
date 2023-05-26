using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class WritterController : Controller
	{
		WritterManager wm = new WritterManager(new EfWritterRepository());
		UserManager userManager = new UserManager(new EfUserRepository());

		private readonly UserManager<AppUser> _userManager;

		public WritterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Authorize]
		public IActionResult Index()
		{
			var userMail = User.Identity.Name;
			ViewBag.v = userMail;
			Context c = new Context();
			var writerName = c.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterName).FirstOrDefault();
			ViewBag.v2 = writerName;
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}

		[AllowAnonymous]
		public PartialViewResult WritterNavbarPartial()
		{
			return PartialView();
		}

		[AllowAnonymous]
		public PartialViewResult WritterFooterPartial()
		{
			return PartialView();
		}

		//[HttpGet]
		//public IActionResult WriterEditProfile()
		//{
		//	Context c = new Context();
		//	var username = User.Identity.Name;
		//	var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
		//	var id = c.Users.Where(x=>x.Email==userMail).Select(y=>y.Id).FirstOrDefault();
		//	var values = userManager.TGetById(id);
		//	return View(values);
		//}

		[HttpGet]
		public async Task<IActionResult> WriterEditProfile()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserUpdateViewModel model = new UserUpdateViewModel();
			model.mail = values.Email;
			model.namesurname = values.NameSurname;
			model.imageurl = values.ImageUrl;
			model.username = values.UserName;
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.NameSurname = model.namesurname;
			values.ImageUrl = model.imageurl;
			values.UserName = model.username;
			values.Email = model.mail;
			values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,model.password);
			var result = await _userManager.UpdateAsync(values);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Dashboard");
			}
			return View();

			//WritterValidator wl = new WritterValidator();
			//ValidationResult results = wl.Validate(p);
			//if (results.IsValid)
			//{
			//	userManager.TUpdate(p);
			//	return RedirectToAction("Index", "Dashboard");
			//}
			//else
			//{
			//	foreach (var item in results.Errors)
			//	{
			//		ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			//	}
			//}

		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WritterAdd()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult WritterAdd(AddProfileImages p)
		{
			Writter w = new Writter();
			if (p.WritterImage != null)
			{
				var extension = Path.GetExtension(p.WritterImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WritterImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				p.WritterImage.CopyTo(stream);
				w.WritterImage = newImageName;
			}
			w.WritterMail = p.WritterMail;
			w.WritterName = p.WritterName;
			w.WritterPassword = p.WritterPassword;
			w.WritterStatus = true;
			w.WritterAbout = p.WritterAbout;
			wm.TAdd(w);
			return RedirectToAction("Index", "Dashboard");
		}
	}
}
