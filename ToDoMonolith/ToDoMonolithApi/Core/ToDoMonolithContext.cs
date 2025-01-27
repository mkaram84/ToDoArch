using Microsoft.EntityFrameworkCore;
using ToDoMonolithApi.Domain.Entities;

namespace ToDoMonolithApi.Core;

public class ToDoMonolithContext(DbContextOptions<ToDoMonolithContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Domain.Entities.Task> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.Tasks).WithOne(t => t.User).HasForeignKey(t => t.UserId);
    }
}
