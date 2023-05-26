using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writter
{
    public class WritterName:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writterName = context.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterName).FirstOrDefault();
            var writterImage = context.Writters.Where(x => x.WritterMail == userMail).Select(y => y.WritterImage).FirstOrDefault();
            ViewBag.name = writterName;
            ViewBag.img = writterImage;
            return View();
        }
    }
}
