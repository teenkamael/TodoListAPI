using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;
using ToDoListApi.Dtos;
using ToDoListApi.Mappers;
using ToDoListApi.Persistance;
using ToDoListApi.Persistance.Contracts;
using ToDoListApi.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("GPChalllengeDb"))
    );
    

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapPost("/Status", async ([FromBody]StatusDto statusDto, IUnitOfWork unitOfWork) =>
{
	var status = StatusMapper.MapStatusDtoToStatus(statusDto);
 
	await unitOfWork.StatusRepository.AddAsync(status);
	await unitOfWork.CommitAsync();
 
	return status;
});

app.Run();
