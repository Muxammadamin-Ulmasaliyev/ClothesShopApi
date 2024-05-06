using ClothesShopDataAccess.IRepositories;
using ClothesShopDomain;
using ClothesShopDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopDataAccess.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _dbContext;
		public ProductRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Product> Create(Product product)
		{
			await _dbContext.Products.AddAsync(product);
			await _dbContext.SaveChangesAsync();
			return product;
		}

		public async Task<bool> Delete(int id)
		{
			var productToDelete = await _dbContext.Products.FindAsync(id);
			if (productToDelete != null)
			{
				_dbContext.Products.Remove(productToDelete);
				await _dbContext.SaveChangesAsync();
				return true;

			}
			return false;
		}

		public async Task<Product> Get(int id)
		{
			return await _dbContext.Products.FindAsync(id);
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task<Product> Update(int id, Product product)
		{
			var updatedProduct = _dbContext.Products.Attach(product);
			updatedProduct.State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return product;
		}
	}
}
