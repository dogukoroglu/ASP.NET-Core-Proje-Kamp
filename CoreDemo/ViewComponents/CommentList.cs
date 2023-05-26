using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
	public class CommentList:ViewComponent
	{
		public IViewComponentResult Invoke() // Invoke => çağrı,çağır anlamında
		{
			var commentValues = new List<UserComment>
			{
				new UserComment
				{
					ID = 1,
					Username = "Test-1",
				},
				new UserComment
				{
					ID = 2,
					Username="Test-2",
				},
				new UserComment
				{
					ID = 3,
					Username="Test-3"
				}
			};
			return View(commentValues);
		}
	}
}
