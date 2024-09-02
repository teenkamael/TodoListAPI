using ToDoListApi.Dtos;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Services.Contracts{
    public interface IStatusService{
        Task<int> CreateStatus(StatusDto status);

        Task<StatusDto> GetStatus(int statusId);

        Task<bool> DeleteStatus(int statusId);

        Task<bool> UpdateStatus(StatusDto status);
    }
}