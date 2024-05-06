using ClothesShopDataAccess.IRepositories;
using ClothesShopDomain;
using ClothesShopDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopDataAccess.Repositories
{
	public class ColorRepository : IColorRepository
	{
		private readonly AppDbContext _dbContext;
		public ColorRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}


		public async Task<Color> Create(Color color)
		{
			await _dbContext.Colors.AddAsync(color);
			await _dbContext.SaveChangesAsync();
			return color;
		}

		public async Task<bool> Delete(int id)
		{
			var colorToDelete = await _dbContext.Colors.FindAsync(id);
			if (colorToDelete != null)
			{
				_dbContext.Colors.Remove(colorToDelete);
				await _dbContext.SaveChangesAsync();
				return true;

			}
			return false;
		}

		public async Task<Color> Get(int id)
		{
			return await _dbContext.Colors.FindAsync(id);
		}

		public async Task<IEnumerable<Color>> GetAll()
		{
			return await _dbContext.Colors.ToListAsync();

		}

		public async Task<Color> Update(int id, Color color)
		{
			var updatedColor = _dbContext.Colors.Attach(color);
			updatedColor.State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return color;
		}
	}
}
