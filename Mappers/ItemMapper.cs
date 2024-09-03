using ToDoListApi.Dtos;
using ToDoListApi.Models;
using ToDoListApi.Types.Enums;
using ToDoListApi.Utils.Temp;

namespace ToDoListApi.Mappers{
    public static class ItemMapper{
        public static ItemDto MapItemToDto(this Item item){
            return new ItemDto(){
                Id = item.Id,
                CreatedAt = item.CreatedAt,
                CreatedBy = item.CreatedBy,
                UpdatedAt = item.UpdatedAt,
                UpdatedBy = item.UpdatedBy,
                Status = (ItemStatus)item.StatusId,
                Type = (ItemTypesEnum)item.ItemTypeId,
                Name = item.Name,
                Description = item.Description
            };
        }

        public static Item MapItemDtoToItem(this ItemDto dto){
            return new Item(){
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                CreatedBy = dto.CreatedBy,
                UpdatedAt = dto.UpdatedAt,
                UpdatedBy = dto.UpdatedBy,
                StatusId = (int)dto.Status,
                ItemTypeId = (int)dto.Type,
                Name = dto.Name,
                Description = dto.Description
            };
        }

        public static ItemDto MapTaskDtoToItemDto(this TaskDto task){
            var dto =  new ItemDto(){
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                Type = ItemTypesEnum.Task
            };

            dto.FillBaseData();
            return dto;
        }
        public static TaskDto MapItemDtoToTaskDto(this ItemDto item){
            var dto =  new TaskDto(){
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Status = item.Status
            };
            return dto;
        }
        public static TaskDto MapItemToTaskDto(this Item item){
            var dto =  new TaskDto(){
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Status = (ItemStatus)item.StatusId
            };
            return dto;
        }

        public static void UpdateItem(this Item item, ItemDto dto){
            item.Description = dto.Description;
            item.Name = dto.Name;
            item.StatusId = (int)dto.Status;
        }
    }
}