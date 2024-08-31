
using ToDoListApi.Models;
using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance.Repositories{
    public class StatusItemTypeRepository : Repository<StatusItemType>, IStatusItemTypesRepository
	{
		public StatusItemTypeRepository (AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}