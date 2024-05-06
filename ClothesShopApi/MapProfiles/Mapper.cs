using ClothesShopApi.Models;
using ClothesShopDomain.Entities;

namespace ClothesShopApi.MapProfiles
{
	public static class Mapper
	{
		public static ProductModel Map(Product product)
		{
			return new ProductModel()
			{
				Id = product.Id,
				NameUZ = product.NameUZ,
				NameEN = product.NameEN,
				NameRU = product.NameRU,
				DescriptionUZ = product.DescriptionUZ,
				DescriptionEN = product.DescriptionEN,
				DescriptionRU = product.DescriptionRU,
				Price = product.Price,
				Gender = product.Gender,
				//Category = product.Category,
				CategoryId = product.CategoryId,
				Color = product.Color,
				Quantity = product.Quantity,
			};
		}

		public static Product Map(ProductModel model)
		{
			return new Product()
			{
				Id = model.Id,
				NameUZ = model.NameUZ,
				NameEN = model.NameEN,
				NameRU = model.NameRU,
				DescriptionUZ = model.DescriptionUZ,
				DescriptionEN = model.DescriptionEN,
				DescriptionRU = model.DescriptionRU,
				Price = model.Price,
				Gender = model.Gender,
				CategoryId = model.CategoryId,
				Color = model.Color,
				Quantity = model.Quantity,
				
			};
		}

		public static CategoryModel Map(Category category)
		{
			return new CategoryModel()
			{
				Id = category.Id,
				NameUZ = category.NameUZ,
				NameEN = category.NameEN,
				NameRU = category.NameRU,
				DescriptionUZ = category.DescriptionUZ,
				DescriptionEN = category.DescriptionEN,
				DescriptionRU = category.DescriptionRU,
				Products = category.Products,
				ProductsCount = category.Products.Count,
			};
		}

		public static Category Map(CategoryModel model)
		{
			return new Category()
			{
				Id = model.Id,
				NameUZ = model.NameUZ,
				NameEN = model.NameEN,
				NameRU = model.NameRU,
				DescriptionUZ = model.DescriptionUZ,
				DescriptionEN = model.DescriptionEN,
				DescriptionRU = model.DescriptionRU,
			};
		}


		


	}
}
