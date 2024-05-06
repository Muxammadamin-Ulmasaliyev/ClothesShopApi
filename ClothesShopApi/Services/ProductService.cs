using ClothesShopApi.MapProfiles;
using ClothesShopApi.Models;
using ClothesShopApi.Services.IServices;
using ClothesShopDataAccess.IRepositories;
using ClothesShopDataAccess.Repositories;

namespace ClothesShopApi.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task<ProductModel> Create(ProductModel model)
		{
			var createdProductEntity = await _productRepository.Create(Mapper.Map(model));
			var createdProductModel = Mapper.Map(createdProductEntity);
			return createdProductModel;
		}

		public async Task<bool> Delete(int id)
		{
			return await _productRepository.Delete(id);

		}

		public async Task<ProductModel> Get(int id)
		{
			var product = await _productRepository.Get(id);
			if (product == null)
			{
				return null;
			}
			return Mapper.Map(product);
		}

		public async Task<IEnumerable<ProductModel>> GetAll()
		{
			var products = await _productRepository.GetAll();
			List<ProductModel> models = new();
			foreach (var product in products)
			{
				var model = Mapper.Map(product);
				models.Add(model);
			}

			return models;
		}

		public async Task<ProductModel> Update(int id, ProductModel model)
		{
			var product = Mapper.Map(model);
			var updatedCategory = await _productRepository.Update(id, product);
			return Mapper.Map(updatedCategory);
		}
		
	}
}
