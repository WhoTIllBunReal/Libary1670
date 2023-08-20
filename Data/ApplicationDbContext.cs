using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Libary1670.Models;

namespace Libary1670.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Libary1670.Models.Products> Products { get; set; } = default!;
		public DbSet<Libary1670.Models.Category> category { get; set; } = default!;
	}
}