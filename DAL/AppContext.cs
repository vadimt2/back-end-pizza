using Common;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleType = "Admin" },
                new Role { Id = 2, RoleType = "User" });

 
        }
    }
}
