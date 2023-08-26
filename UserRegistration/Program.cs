using Microsoft.EntityFrameworkCore;
using Roles.Interface;
using ToDoList.Interface;
using ToDoList.Repository;
using UserRegistration;
using UserRegistration.Repository;
using UserRepository.Models.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<IRoleRepository, RolesRepository>();
builder.Services.AddScoped< IUserRolesRepository ,UserRolesRepository >();



builder.Services.AddDbContext<MyDbContext>(options => {
    options.UseSqlServer("Data Source=.;Initial Catalog=UserRegistrationDb;User ID=sa;Password=P@ssw0rd; TrustServerCertificate=True;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
