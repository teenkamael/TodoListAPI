
using ToDoListApi.Models;
using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance.Repositories{
    public class StatusItemTypesRepository : Repository<StatusItemType>, IStatusItemTypesRepository
	{
		public StatusItemTypesRepository (AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}