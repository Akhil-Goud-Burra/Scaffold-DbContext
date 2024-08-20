using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace crud.Models;

public partial class MyDbContext : DbContext
{

    private readonly IConfiguration _configuration;

    public MyDbContext(IConfiguration configuration,  DbContextOptions<MyDbContext> options)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<EmployeeTable> EmployeeTables { get; set; }

    public virtual DbSet<JobDescription> JobDescriptions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("CRUD");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobDescription>(entity =>
        {
            entity.HasOne(d => d.Employee)
                  .WithMany(p => p.JobDescriptions)
                  .HasForeignKey(d => d.EmployeeId) // Ensure the correct foreign key is used
                  .OnDelete(DeleteBehavior.Cascade) // This enables cascade delete
                  .HasConstraintName("FK_JobDescription_EmployeeTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
