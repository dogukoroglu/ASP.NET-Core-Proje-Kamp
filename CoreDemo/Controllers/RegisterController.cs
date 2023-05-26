using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		WritterManager writterManager = new WritterManager(new EfWritterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writter writter)
		{
			WritterValidator wv = new WritterValidator();
			ValidationResult results =  wv.Validate(writter);

			if (results.IsValid)
			{
				writter.WritterStatus = true;
				writter.WritterAbout = "Deneme Test";
				writterManager.TAdd(writter);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
