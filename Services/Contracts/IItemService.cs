using ToDoListApi.Dtos;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Services.Contracts{
    public interface IItemService{
        Task<int> CreateItem(ItemDto item);

        Task<ItemDto> GetItem(int itemId);

        Task<bool> DeleteItem(int itemId);

        Task<bool> UpdateItem(ItemDto item);

        Task<IEnumerable<TaskDto>> GetAllTasks();
        Task<IEnumerable<TaskDto>> GetTasksByStatus(ItemStatus status);
    }
}