using ClothesShopDataAccess.IRepositories;
using ClothesShopDomain;
using ClothesShopDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopDataAccess.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly AppDbContext _dbContext;
		public CategoryRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Category> Create(Category category)
		{
			await _dbContext.Categories.AddAsync(category);
			await _dbContext.SaveChangesAsync();
			return category;
		}

		public async Task<bool> Delete(int id)
		{
			var categoryToDelete = await _dbContext.Categories.FindAsync(id);
			if (categoryToDelete != null)
			{
				_dbContext.Categories.Remove(categoryToDelete);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<Category> Get(int id)
		{
			return await _dbContext.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<IEnumerable<Category>> GetAll()
		{
			return await _dbContext.Categories.ToListAsync();
		}

		public async Task<Category> Update(int id, Category category)
		{
			var updatedCategory = _dbContext.Categories.Attach(category);
			updatedCategory.State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return category;
		}
	}
}
