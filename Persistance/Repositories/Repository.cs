using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;
using ToDoListApi.Persistance.Contracts;
using ToDoListApi.Utils.Temp;

namespace ToDoListApi.Persistance.Repositories{
    public class Repository<T> : IRepository<T> where T : AbstractModel
	{
		private readonly AppDbContext dbContext;
		public Repository (AppDbContext dbContext)
		{

			this.dbContext = dbContext;
		}

		public async Task AddAsync (T entity)
		{
			StartTransaction(entity);
			await dbContext.Set<T>().AddAsync(entity);
		}

		public async Task<bool> DeleteAsync (int id)
		{
			var entity = await FindAsync (id);

			if(entity == null)
			{
				return false;
			}
			
			StartTransaction(entity);
			dbContext.Set<T>().Remove(entity);
			return true;
		}

		public async Task<T?> FindAsync (int id)
		{
			return await dbContext.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync ()
		{
			return await dbContext.Set<T>().ToListAsync();
		}

		public T Update (T entity)
		{
			StartTransaction(entity);
			dbContext.Set<T>().Update(entity);	
			return entity;
		}

		private void StartTransaction(T entity){
			var dbData = dbContext.Set<T>().FirstOrDefault(x => entity.Id == x.Id);
			entity.GetUserData(); //Deletion or method modification needed when authorization manager is completed.
			if (dbData != null){
				entity.CreatedAt = dbData.CreatedAt.ToUniversalTime();
				entity.CreatedBy = dbData.CreatedBy;
				entity.UpdatedAt = DateTime.Now.ToUniversalTime();
			}
			else{
				entity.CreatedAt = DateTime.Now.ToUniversalTime();
				entity.UpdatedAt = DateTime.Now.ToUniversalTime();
			}
		}
		
	}
}
