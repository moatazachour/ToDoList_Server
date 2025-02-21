using ToDoList_BusinessLayer;
using ToDoList_DataAccessLayer;
using ToDoList_DataAccessLayer.DataAccessClasses;
using ToDoList_DataAccessLayer.DTO;
using ToDoList_DataAccessLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register configuration manager
var configuration = builder.Configuration;

// Services
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddSingleton<DatabaseConnectionService>();

builder.Services.AddScoped<IUserData, clsUserData>();
builder.Services.AddScoped<clsUser>();

builder.Services.AddScoped<ITask, clsTaskData>();
builder.Services.AddScoped<clsTask>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// enable CORS services to the container
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
