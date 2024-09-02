using ToDoListApi.Persistance;
using ToDoListApi.Persistance.Contracts;
using ToDoListApi.Persistance.Repositories;
using ToDoListApi.Services.Contracts;
using ToDoListApi.Services.Implementation;

namespace ToDoListApi.Registration{
    public static class IocRegistration{
        public static IServiceCollection AddRegistration(this IServiceCollection services){
            services.RegisterServices();
            services.RegisterRepositories();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        } 

        public static IServiceCollection RegisterServices(this IServiceCollection services){
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IItemTypeService, ItemTypeService>();
            services.AddScoped<IAdminService, AdminService>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services){
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusItemTypesRepository, StatusItemTypesRepository>();
            services.AddScoped<IItemTypesRepository, ItemTypesRepository>();
            services.AddScoped<IItemsRepository, ItemsRepository>();

            return services;
        }
    }
}