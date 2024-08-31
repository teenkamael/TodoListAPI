namespace ToDoListApi.Persistance.Contracts{
    
public interface IUnitOfWork
	{
		IUsersRepository UsersRepository { get; }
        IStatusRepository StatusRepository {get;}
        IStatusItemTypesRepository StatusItemTypesRepository {get;}
        IItemTypesRepository ItemTypesRepository {get;}
        IItemRepository ItemRepository {get;}
		void DisposeContext ();
		Task<int> CommitAsync ();
	}
}