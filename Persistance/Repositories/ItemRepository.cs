
using ToDoListApi.Models;
using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance.Repositories{
    public class ItemsRepository : Repository<Item>, IItemsRepository
	{
		public ItemsRepository (AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}