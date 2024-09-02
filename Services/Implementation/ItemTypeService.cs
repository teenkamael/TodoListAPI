
using ToDoListApi.Dtos;
using ToDoListApi.Mappers;
using ToDoListApi.Persistance.Contracts;
using ToDoListApi.Services.Contracts;

namespace ToDoListApi.Services.Implementation{
    public class ItemTypeService : IItemTypeService{

        private readonly IUnitOfWork _unitOfWork;

        public ItemTypeService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateItemType(ItemTypeDto itemTypeDto)
        {
            var itemType = ItemTypeMapper.MapItemTypeDtoToItemType(itemTypeDto);
        
            await _unitOfWork.ItemTypesRepository.AddAsync(itemType);
            await _unitOfWork.CommitAsync();
        
            return itemType.Id;
        }

        public async Task<bool> DeleteItemType(int itemTypeId)
        {
            var itemType = await _unitOfWork.ItemTypesRepository.FindAsync(itemTypeId);
            if(itemType == null){
                throw new KeyNotFoundException("ItemType not found for deletion");
            }
            await _unitOfWork.ItemTypesRepository.DeleteAsync(itemTypeId);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateItemType(ItemTypeDto itemType)
        {
            var dbItemType = await _unitOfWork.ItemTypesRepository.FindAsync(itemType.Id);
            if(dbItemType == null){
                throw new KeyNotFoundException("ItemType not found for update");
            }
            dbItemType = ItemTypeMapper.MapItemTypeDtoToItemType(itemType);
            _unitOfWork.ItemTypesRepository.Update(dbItemType);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<ItemTypeDto> GetItemType(int itemTypeId)
        {
            var itemType = await _unitOfWork.ItemTypesRepository.FindAsync(itemTypeId);
            if(itemType == null){
                throw new KeyNotFoundException("ItemType not found");
            }

            return ItemTypeMapper.MapItemTypeToDto(itemType);
        }
    }
}