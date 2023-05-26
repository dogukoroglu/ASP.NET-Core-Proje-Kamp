using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// connecting string tanımlanacak.
			optionsBuilder.UseSqlServer("server=LAPTOP-GPMKKC5N\\SQLEXPRESS;database=CoreBlogApiDb; integrated security=true;TrustServerCertificate=True;");
		}
        public DbSet<Employee> Employees { get; set; }
    }
}
