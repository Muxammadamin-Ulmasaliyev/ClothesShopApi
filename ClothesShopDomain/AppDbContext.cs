using ClothesShopDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopDomain
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
		{

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Color> Colors { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			/*modelBuilder.Entity<Product>()
				.Property(p => p.Sizes)
				.HasConversion(
					v => string.Join(',', v),
					v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));*/


			modelBuilder.Entity<Product>()
				.HasMany(e => e.Colors)
				.WithMany(e => e.Products)
				.UsingEntity<ProductColor>();

		}
	}
}
