using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Split_IT.Entities;

namespace Split_IT.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; } 
        public DbSet<Group> Groups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
              .HasMany(g => g.Expenses)
              .WithOne(e => e.Group);

            modelBuilder.Entity<UserGroup>().HasKey(ug => new {ug.GroupId, ug.UserId});

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(ug => ug.Groups)
                .HasForeignKey(ug => ug.UserId);
                

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(ug => ug.Users)
                .HasForeignKey(ug => ug.GroupId);



            base.OnModelCreating(modelBuilder);
        }

    }
}
