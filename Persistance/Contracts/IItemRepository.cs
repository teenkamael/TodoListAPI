using ToDoListApi.Models;

namespace ToDoListApi.Persistance.Contracts{
    public interface IItemsRepository : IRepository<Item>
	{
	}
}