using ClothesShopApi.MapProfiles;
using ClothesShopApi.Models;
using ClothesShopApi.Services.IServices;
using ClothesShopDataAccess.IRepositories;

namespace ClothesShopApi.Services
{
	public class CategoryService : ICategoryService
	{

		private readonly ICategoryRepository _categoryRepository;
		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<CategoryModel> Create(CategoryModel model)
		{

			var createdCategoryEntity = await _categoryRepository.Create(Mapper.Map(model));
			var createdCategoryModel = Mapper.Map(createdCategoryEntity);
			return createdCategoryModel;

		}

		public async Task<bool> Delete(int id)
		{
			return await _categoryRepository.Delete(id);
		}

		public async Task<CategoryModel> Get(int id)
		{
			var category = await _categoryRepository.Get(id);
			if (category == null)
			{
				return null;
			}
			return Mapper.Map(category);
		}

		public async Task<IEnumerable<CategoryModel>> GetAll()
		{
			var categories = await _categoryRepository.GetAll();
			List<CategoryModel> models = new();
			foreach (var category in categories)
			{
				var model = Mapper.Map(category);
				models.Add(model);
			}

			return models;
		}

		public async Task<CategoryModel> Update(int id, CategoryModel model)
		{
			var category = Mapper.Map(model);
			var updatedCategory = await _categoryRepository.Update(id, category);
			return Mapper.Map(updatedCategory);
		}
	}
}
