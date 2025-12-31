using Microsoft.EntityFrameworkCore;
using ProjectR.Entities;

namespace ProjectR.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<Media> Media { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Data\\database.db");
    }
}
