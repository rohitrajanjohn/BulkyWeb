using BulkyRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyRazor.Data
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{
			
		}
		public DbSet<Category> Categories { get; set; }
	}
}
