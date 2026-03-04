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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Project <-> User (Many-to-Many)
        modelBuilder.Entity<ProjectEntity>()
            .HasMany(p => p.Users)
            .WithMany(u => u.Projects);

        // Project -> Task (One-to-Many)
        modelBuilder.Entity<ProjectEntity>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId);

        // Task <-> User (Many-to-Many)
        modelBuilder.Entity<TaskEntity>()
            .HasMany(t => t.Users)
            .WithMany(u => u.Tasks);
    }
}
