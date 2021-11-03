using Neptune.Models;
using Microsoft.EntityFrameworkCore;

namespace Neptune.Data
{
    public class DatabaseDbContext : DbContext
    {
        public DbSet<Option> options {get; set; }
        public DbSet<Parameter> parameter {get; set; }
        public DbSet<Script> scripts {get; set; }
        public DbSet<User> user {get; set; }
        public DbSet<Test> test {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=C:/Users/pi890/OneDrive/Desktop/Neptune_api/neptune.db");
    }
}