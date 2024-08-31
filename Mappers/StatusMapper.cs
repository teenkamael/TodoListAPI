using Riok.Mapperly.Abstractions;
using ToDoListApi.Dtos;
using ToDoListApi.Models;

namespace ToDoListApi.Mappers{
    [Mapper]
    public static partial class StatusMapper{
        public static partial StatusDto MapStatusToDto (Status status);
        public static partial Status MapStatusDtoToStatus (StatusDto status);
    }
}