namespace ToDoListApi.Dtos.Models
{
    public class BaseDto
    {
        public int Id;

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}