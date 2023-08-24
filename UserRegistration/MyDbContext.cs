using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using UserRegistration.Models;

namespace UserRegistration;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<ToDoModel> ToDos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }


}
