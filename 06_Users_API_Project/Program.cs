using _06_Users_API_Project.Interface;
using _06_Users_API_Project.Model;
using _06_Users_API_Project.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionstring = builder.Configuration.GetConnectionString("dbcs") ?? throw new InvalidOperationException("Connection string not found ");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring));
builder.Services.AddScoped<IUserRepository, UserRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
