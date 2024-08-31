
using ToDoListApi.Models;
using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance.Repositories{
    public class StatusRepository : Repository<Status>, IStatusRepository
	{
		public StatusRepository (AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}