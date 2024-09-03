using ToDoListApi.Dtos.Models;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }
    }
}