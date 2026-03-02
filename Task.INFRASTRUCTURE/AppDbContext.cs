using Microsoft.EntityFrameworkCore;
using TaskManagement.ENTITIES.Entities;

namespace TaskManagement.INFRASTRUCTURE;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
}
