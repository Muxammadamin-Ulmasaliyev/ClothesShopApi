using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClothesShopDomain.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string NameUZ { get; set; }
		public string NameEN { get; set; }
		public string NameRU { get; set; }
		public string? DescriptionUZ { get; set; }
		public string? DescriptionEN { get; set; }
		public string? DescriptionRU { get; set; }
		public double Price { get; set; }
		public bool Gender { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }



        // Relationships 
        public int CategoryId { get; set; }

		//public Category Category { get; set; }



	}
}
