using Riok.Mapperly.Abstractions;
using ToDoListApi.Dtos;
using ToDoListApi.Models;

namespace ToDoListApi.Mappers{
    [Mapper]
    public static partial class ItemTypeMapper{
        public static partial ItemTypeDto MapItemTypeToDto (ItemType status);
        public static partial ItemType MapItemTypeDtoToItemType (ItemTypeDto status);
    }
}