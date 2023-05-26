namespace CoreDemo.Models
{
	public class RoleUpdateViewModel
	{
        public int Id { get; set; }
        public string name { get; set; }
    }
}

// Update işleminde ilk olarak role değerini bulmamız lazım, sonra bulunan role değerine göre işlem yapılacak