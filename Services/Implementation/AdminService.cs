using ToDoListApi.Persistance.Contracts;
using ToDoListApi.Services.Contracts;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Services.Implementation{
    public class AdminService : IAdminService
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddItemTypeAndStatusRelation(Types.Enums.ItemStatus taskStatus, ItemTypesEnum itemType)
        {
            var dbItemType = await _unitOfWork.ItemTypesRepository.FindAsync((int)itemType);
            var dbStatus = await _unitOfWork.StatusRepository.FindAsync((int)taskStatus);
            if(dbItemType == null || dbStatus == null){
                throw new KeyNotFoundException("One of the relation items is not found");
            }
            dbItemType.RelatedStatus.Add(dbStatus);
            _unitOfWork.ItemTypesRepository.Update(dbItemType);
            
            return true;
        }
    }
}