using FA.Model;
using Microsoft.EntityFrameworkCore;
namespace FA.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-VN7D46F; database = SchoolDbFa; Trusted_Connection=True; " +
                "TrustServerCertificate=True");
        }
    }
}
