namespace ToDoListApi.Models.Contracts
{
    public interface INameAndDescription
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}