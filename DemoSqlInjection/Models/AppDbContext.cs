// AppDbContext.cs
using DemoSqlInjection.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class AppDbContext : DbContext
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Tasks> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=MY_LAPTOP\\DUCTAI;Initial Catalog=DemoSqlInjection;Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tasks>()
            .HasOne(u => u.Users)
            .WithMany(t => t.Tasks)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

        base.OnModelCreating(modelBuilder);
    }
}
