
using ToDoListApi.Models;
using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance.Repositories{
    public class ItemTypesRepository : Repository<ItemType>, IItemTypesRepository
	{
		public ItemTypesRepository (AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}