namespace ClothesShopApi.Services.IServices
{
	public interface IGenericCRUDService<T> where T : class
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int id);

		Task<T> Create(T item);

		Task<T> Update(int id, T item);
		Task<bool> Delete(int id);
	}
}
