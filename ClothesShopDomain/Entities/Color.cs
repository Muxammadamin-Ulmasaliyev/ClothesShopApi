﻿namespace ClothesShopDomain.Entities
{
	public class Color
	{
        public int Id { get; set; }
		public string NameUZ { get; set; }
		public string NameRU { get; set; }
		public string NameEN { get; set; }


		// Relationships

		public List<Product>? Products { get; } = [];

		public List<ProductColor>? ProductColors { get; set; } = [];

    }
}
