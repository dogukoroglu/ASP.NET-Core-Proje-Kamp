using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { categoryname = "TEKNOLOJİ", categorycount = 10 });
            list.Add(new CategoryClass { categoryname = "YAZILIM", categorycount = 14 });
            list.Add(new CategoryClass { categoryname = "SPOR", categorycount = 5 });

            return Json(new {jsonlist=list});
        }
    }
}
