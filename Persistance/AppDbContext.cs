using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;

namespace ToDoListApi.Persistance{
    public class AppDbContext: DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options){

        }

        public virtual DbSet<User> Users {get; set;}   
        public virtual DbSet<Status> Status {get; set;}   
        public virtual DbSet<ItemType> ItemTypes {get; set;}   
        public virtual DbSet<StatusItemType> StatusItemTypes {get; set;}   
        public virtual DbSet<Item> Items {get; set;}   
    }


}