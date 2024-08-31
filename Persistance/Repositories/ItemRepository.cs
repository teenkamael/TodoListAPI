
using ToDoListApi.Models;
using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance.Repositories{
    public class ItemRepository : Repository<Item>, IItemRepository
	{
		public ItemRepository (AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}