using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writter
{
    public class WritterMessageNotification:ViewComponent
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writterId = c.Writters.Where(x => x.WritterMail == usermail).Select(y => y.WritterID).FirstOrDefault();
			var values = message2Manager.GetInboxListByWritter(writterId);
            return View(values);
        }
    }
}
