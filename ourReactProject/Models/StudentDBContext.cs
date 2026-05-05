using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ourReactProject.Models
{
    public class StudentDBContext: DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        { 
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS; Database = StudentData;Trusted_Connection = True; TrustServerCertificate=True;"
                );
        }
    }
}
