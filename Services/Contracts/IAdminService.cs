using ToDoListApi.Types.Enums;

namespace ToDoListApi.Services.Contracts{
    public interface IAdminService{
        Task<bool> AddItemTypeAndStatusRelation(Types.Enums.ItemStatus taskStatus, ItemTypesEnum itemType);
        // Task<bool> AddUser(UserDto)
        // Task<bool> AuthorizeUser(userDto)
    }
}