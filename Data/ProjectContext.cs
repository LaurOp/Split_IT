using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Split_IT.Entities;
using Split_IT.Entities.Models;

namespace Split_IT.Data
{
    public class ProjectContext : IdentityDbContext<UserAuth, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {


        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; } 
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<AmountOwed> AmountsOwed { get; set; }
        public DbSet<Friendship> Friendships { get; set; }



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


            modelBuilder.Entity<Expense>()
                .HasMany(e => e.AmountsOwed)
                .WithOne(a => a.Expense);


            modelBuilder.Entity<User>()
                .HasMany(u => u.AmountsOwed)
                .WithOne(a => a.User);


            modelBuilder.Entity<Friendship>()
                .HasKey(f => new { f.FromId, f.ToId });

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.UserFrom)
                .WithMany()
                .HasForeignKey(f => f.FromId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.UserTo)
                .WithMany(f => f.FriendWith)
                .HasForeignKey(f => f.ToId);



            base.OnModelCreating(modelBuilder);
        }

    }
}
