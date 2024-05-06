using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShopDomain.Entities
{
	public class ProductColor
	{
        public int ProductId { get; set; }
        public int ColorId { get; set; }
		public Product Product { get; set; } = null!;
		public Color Color { get; set; } = null!;
	}
}
