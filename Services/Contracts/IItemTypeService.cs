using ToDoListApi.Dtos;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Services.Contracts{
    public interface IItemTypeService{
        Task<int> CreateItemType(ItemTypeDto itemType);

        Task<ItemTypeDto> GetItemType(int itemTypeId);

        Task<bool> DeleteItemType(int itemTypeId);

        Task<bool> UpdateItemType(ItemTypeDto itemType);
    }
}