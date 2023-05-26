using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writter
{
    public class WritterNavbarName:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerName = context.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterName).FirstOrDefault();
            var writerImage = context.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterImage).FirstOrDefault();
            ViewBag.name = writerName;
            ViewBag.img = writerImage;
            return View();
        }
    }
}
