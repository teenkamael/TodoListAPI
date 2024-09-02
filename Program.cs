using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Dtos;
using ToDoListApi.Mappers;
using ToDoListApi.Persistance;
using ToDoListApi.Persistance.Contracts;
using ToDoListApi.Persistance.Repositories;
using ToDoListApi.Registration;
using ToDoListApi.Services.Contracts;
using ToDoListApi.Types.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("GPChalllengeDb"))
    );
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddRegistration();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");
app.MapPost("/Status/Create", async ([FromBody]StatusDto statusDto, IStatusService statusService) =>
{
	await statusService.CreateStatus(statusDto);
    
	return StatusMapper.MapStatusDtoToStatus(statusDto);
});
app.Run();
