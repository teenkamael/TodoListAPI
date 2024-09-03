using ToDoListApi.Dtos;
using ToDoListApi.Mappers;
using ToDoListApi.Persistance.Contracts;
using ToDoListApi.Services.Contracts;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Services.Implementation{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateItem(ItemDto dto)
        {
            if(!dto.Validation())
                throw new ArgumentNullException("Name and Description must have values");
            var item = ItemMapper.MapItemDtoToItem(dto);

            
            await _unitOfWork.ItemRepository.AddAsync(item);
            await _unitOfWork.CommitAsync();

            return item.Id;
        }

        public async Task<bool> DeleteItem(int itemId)
        {
            var item = await _unitOfWork.ItemRepository.FindAsync(itemId);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found for deletion");
            }
            await _unitOfWork.ItemRepository.DeleteAsync(itemId);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            var items = await _unitOfWork.ItemRepository.GetAllAsync();
            return items.Where(x => x.ItemTypeId == (int)ItemTypesEnum.Task).
            Select(x => ItemMapper.MapItemToTaskDto(x));
        }

        public async Task<IEnumerable<TaskDto>> GetTasksByStatus(ItemStatus status)
        {
            var items = await _unitOfWork.ItemRepository.GetAllAsync();
            return items.Where(x => x.ItemTypeId == (int)ItemTypesEnum.Task && x.StatusId == (int)status).
            Select(x => ItemMapper.MapItemToTaskDto(x));
        }



        public async Task<ItemDto> GetItem(int itemId)
        {
            var item = await _unitOfWork.ItemRepository.FindAsync(itemId);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            return ItemMapper.MapItemToDto(item);
        }
        
        public async Task<bool> UpdateItem(ItemDto dto)
        {
            if(!dto.Validation())
                throw new ArgumentNullException("Name and Description must have values");
            var item = await _unitOfWork.ItemRepository.FindAsync(dto.Id);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found for update");
            }
            item.UpdateItem(dto);
            _unitOfWork.ItemRepository.Update(item);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}