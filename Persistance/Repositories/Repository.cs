using Microsoft.EntityFrameworkCore;
using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance.Repositories{
    public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext dbContext;
		public Repository (AppDbContext dbContext)
		{

			this.dbContext = dbContext;
		}

		public async Task AddAsync (T entity)
		{
			await dbContext.Set<T>().AddAsync (entity);
		}

		public async Task<bool> DeleteAsync (Guid id)
		{
			var entity = await FindAsync (id);

			if(entity == null)
			{
				return false;
			}

			dbContext.Set<T>().Remove(entity);
			return true;
		}

		public async Task<T?> FindAsync (Guid id)
		{
			return await dbContext.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync ()
		{
			return await dbContext.Set<T>().ToListAsync();
		}

		public T Update (T entity)
		{
			dbContext.Set<T>().Update (entity);	
			return entity;
		}
	}
}
