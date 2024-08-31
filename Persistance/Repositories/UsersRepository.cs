
using ToDoListApi.Models;
using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance.Repositories{
    public class UsersRepository : Repository<User>, IUsersRepository
	{
		public UsersRepository (AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}