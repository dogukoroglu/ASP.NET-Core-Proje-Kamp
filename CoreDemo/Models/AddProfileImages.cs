using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
	public class AddProfileImages
	{
		public int WritterID { get; set; }
		public string WritterName { get; set; }
		public string WritterAbout { get; set; }
		public IFormFile WritterImage { get; set; }
		public string WritterMail { get; set; }
		public string WritterPassword { get; set; }
		public bool WritterStatus { get; set; }
	}
}
