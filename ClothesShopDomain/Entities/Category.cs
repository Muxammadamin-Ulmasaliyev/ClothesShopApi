namespace ClothesShopDomain.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string NameUZ { get; set; }
		public string NameRU { get; set; }
		public string NameEN { get; set; }
		public string? DescriptionUZ { get; set; }
		public string? DescriptionRU { get; set; }
		public string? DescriptionEN { get; set; }

		public List<Product> Products { get; set; }
	}
}
