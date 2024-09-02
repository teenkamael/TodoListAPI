using ToDoListApi.Models;

namespace ToDoListApi.Persistance.Contracts{
    public interface IRepository<T> where T : AbstractModel
	{
		Task AddAsync(T entity);
		T Update(T entity);
		Task<bool> DeleteAsync(int id);
		Task<T?> FindAsync(int id);
		Task<List<T>> GetAllAsync();
	}
}