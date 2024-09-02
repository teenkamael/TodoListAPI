using ToDoListApi.Persistance.Contracts;

namespace ToDoListApi.Persistance
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;
        public IUsersRepository UsersRepository { get; private set; }
        public IStatusRepository StatusRepository {get; private set; }
        public IStatusItemTypesRepository StatusItemTypesRepository {get; private set; }
        public IItemTypesRepository ItemTypesRepository {get; private set; }
        public IItemsRepository ItemRepository {get; private set; }
        private bool disposed = false;
        public UnitOfWork(AppDbContext appDbContext, IUsersRepository usersRepository, IStatusRepository statusRepository,
                            IStatusItemTypesRepository statusItemTypesRepository, IItemTypesRepository itemTypesRepository, IItemsRepository itemRepository)
        {
            _appDbContext = appDbContext;
            UsersRepository = usersRepository;
            StatusRepository = statusRepository;
            StatusItemTypesRepository = statusItemTypesRepository;
            ItemTypesRepository = itemTypesRepository;
            ItemRepository = itemRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (disposed) return;

            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _appDbContext.Dispose();
                disposed = true;
            }
        }

        public void DisposeContext()
        {
            Dispose();
        }
    }
}