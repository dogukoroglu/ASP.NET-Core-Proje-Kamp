using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Reflection.Metadata;

namespace CoreDemo.Controllers
{
	public class BlogController : Controller
	{
		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());
		Context c = new Context();

		[AllowAnonymous]
		public IActionResult Index()
		{
			var values = blogManager.GetBlogListWithCategory();
			return View(values);
		}
		[AllowAnonymous]
		public IActionResult BlogReadAll(int id)
		{
			ViewBag.i = id;
			ViewBag.CommentId = id;
			var values = blogManager.GetBlogById(id);
			return View(values);
		}

		public IActionResult BlogListByWritter()
		{
			var username = User.Identity.Name;
			var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerId = c.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterID).FirstOrDefault();
			var values = blogManager.GetListWithCategoryByWritterBm(writerId);
			return View(values);
		}

		[HttpGet]
		public IActionResult BlogAdd()
		{
			List<SelectListItem> categoryvalues = (from x in cm.GetList()
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID.ToString()
												   }).ToList();
			ViewBag.cv = categoryvalues;
			return View();
		}

		[HttpPost]
		public IActionResult BlogAdd(Blog p)
		{
			//var username = User.Identity.Name;
			//var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			//var writerId = c.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterID).FirstOrDefault();
			//p.BlogStatus = true;
			//p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			//p.WritterID = writerId;
			//blogManager.TAdd(p);
			//return RedirectToAction("BlogListByWritter", "Blog");

			BlogValidator bv = new BlogValidator();
			ValidationResult results = bv.Validate(p);
			var userName = User.Identity.Name;
			var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
			var writerId = c.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterID).FirstOrDefault();
			if (results.IsValid)
			{

				p.BlogStatus = true;
				p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				p.WritterID = writerId;
				blogManager.TAdd(p);
				return RedirectToAction("BlogListByWritter");



			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			return View();
		}

		public IActionResult DeleteBlog(int id)
		{
			var blogvalue = blogManager.TGetById(id);
			blogManager.TDelete(blogvalue);
			return RedirectToAction("BlogListByWritter");
		}

		[HttpGet]
		public IActionResult EditBlog(int id)
		{
			var blogvalue = blogManager.TGetById(id);
			List<SelectListItem> categoryvalues = (from x in cm.GetList()
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID.ToString()
												   }).ToList();
			ViewBag.cv = categoryvalues;
			return View(blogvalue);
		}

		[HttpPost]
		public IActionResult EditBlog(Blog p)
		{
			var username = User.Identity.Name;
			var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerId = c.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterID).FirstOrDefault();
			p.WritterID = writerId;
			p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.BlogStatus = true;
			blogManager.TUpdate(p);
			return RedirectToAction("BlogListByWritter");
		}
	}
}
