using Microsoft.EntityFrameworkCore;
using SilencershopTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SilencershopTest.DataAccess
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id=1,
                    UserName = "Chaman",
                    Email = "chaman.raghav@vicesoftware.com",
                    Password = "123465487"
                },
                new User
                {
                    Id=2,
                    UserName="Sanjeev",
                    Email="sanjeevsharma@vicesofteware.com",
                    Password="12457845"
                });
        }
    }
}
