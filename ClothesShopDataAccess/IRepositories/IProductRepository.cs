using ClothesShopDataAccess.Generics;
using ClothesShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShopDataAccess.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
	{
	}
}
