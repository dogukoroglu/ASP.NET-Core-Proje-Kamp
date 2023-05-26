using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class WritterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WritterList()
		{
			var jsonWritters = JsonConvert.SerializeObject(writters);
			return Json(jsonWritters);
		}

		public IActionResult GetWritterByID(int writterid)
		{
			var findWriter = writters.FirstOrDefault(x => x.Id == writterid);
			var jsonWritters = JsonConvert.SerializeObject(findWriter);
			return Json(jsonWritters);
        }

		[HttpPost]
		public IActionResult AddWritter(WritterClass w)
		{
			writters.Add(w);
			var jsonWritters = JsonConvert.SerializeObject(w);
			return Json(jsonWritters);
		}

		public IActionResult DeleteWritter(int id)
		{
			var writter = writters.FirstOrDefault(x=>x.Id == id);
			writters.Remove(writter);
			return Json(writter);
		}

		public IActionResult UpdateWritter(WritterClass w)
		{
			var writter = writters.FirstOrDefault(x=>x.Id == w.Id);
			writter.Name = w.Name;
			var jsonWritter = JsonConvert.SerializeObject(w);
			return Json(jsonWritter);
		}

		public static List<WritterClass> writters = new List<WritterClass>
		{
			new WritterClass
			{
				Id = 1,
				Name="Ayşe"
			},
			new WritterClass
			{
				Id = 2,
				Name="Ahmet"
			},
			new WritterClass
			{
				Id = 3,
				Name="Buse"
			}
		};
	}
}
