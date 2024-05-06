using ClothesShopApi.MapProfiles;
using ClothesShopApi.Models;
using ClothesShopApi.Services.IServices;
using ClothesShopDataAccess.IRepositories;
using ClothesShopDataAccess.Repositories;
using ClothesShopDomain.Entities;

namespace ClothesShopApi.Services
{
	public class ColorService : IColorService
	{
		private readonly IColorRepository _colorRepository;
		public ColorService(IColorRepository colorRepository)
		{
			_colorRepository = colorRepository;
		}


		public async Task<ColorModel> Create(ColorModel model)
		{
			var createdColorEntity = await _colorRepository.Create(Mapper.Map(model));
			var createdCategoryModel = Mapper.Map(createdColorEntity);
			return createdCategoryModel;
		}

		public async Task<bool> Delete(int id)
		{
			return await _colorRepository.Delete(id);

		}

		public async Task<ColorModel> Get(int id)
		{
			var color = await _colorRepository.Get(id);
			if (color == null)
			{
				return null;
			}
			return Mapper.Map(color);
		}

		public async Task<IEnumerable<ColorModel>> GetAll()
		{
			var colors = await _colorRepository.GetAll();
			List<ColorModel> models = new();
			foreach (var color in colors)
			{
				var model = Mapper.Map(color);
				models.Add(model);
			}

			return models;
		}

		public async Task<ColorModel> Update(int id, ColorModel model)
		{
			var color = Mapper.Map(model);
			var updatedColor = await _colorRepository.Update(id, color);
			return Mapper.Map(updatedColor);
		}
	}
}
