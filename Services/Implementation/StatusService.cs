
using ToDoListApi.Dtos;
using ToDoListApi.Mappers;
using ToDoListApi.Persistance.Contracts;
using ToDoListApi.Services.Contracts;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Services.Implementation
{
    public class StatusService : IStatusService
    {

        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateStatus(StatusDto statusDto)
        {
            var status = StatusMapper.MapStatusDtoToStatus(statusDto);

            await _unitOfWork.StatusRepository.AddAsync(status);
            await _unitOfWork.CommitAsync();

            return status.Id;
        }

        public async Task<bool> DeleteStatus(int statusId)
        {
            var status = await _unitOfWork.StatusRepository.FindAsync(statusId);
            if (status == null)
            {
                throw new KeyNotFoundException("Status not found for deletion");
            }
            await _unitOfWork.StatusRepository.DeleteAsync(statusId);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateStatus(StatusDto status)
        {
            var dbStatus = await _unitOfWork.StatusRepository.FindAsync(status.Id);
            if (dbStatus == null)
            {
                throw new KeyNotFoundException("Status not found for update");
            }
            dbStatus = StatusMapper.MapStatusDtoToStatus(status);
            _unitOfWork.StatusRepository.Update(dbStatus);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<StatusDto> GetStatus(int statusId)
        {
            var status = await _unitOfWork.StatusRepository.FindAsync(statusId);
            if (status == null)
            {
                throw new KeyNotFoundException("Status not found");
            }

            return StatusMapper.MapStatusToDto(status);
        }
    }
}