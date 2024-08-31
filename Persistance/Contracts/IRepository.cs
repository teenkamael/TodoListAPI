namespace ToDoListApi.Persistance.Contracts{
    public interface IRepository<T> where T : class
	{
		Task AddAsync(T entity);
		T Update(T entity);
		Task<bool> DeleteAsync(Guid id);
		Task<T?> FindAsync(Guid id);
		Task<List<T>> GetAllAsync();
	}
}