using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;

namespace WebApplication1
{
    public class Datab : DbContext
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student408\Desktop\21day.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
        public DbSet<Students> Students { get; set; }
        public DbSet<Facultative> Facultative { get; set; }
        public DbSet<FacultativeRecord> FacultativeRecord { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connect);
        }
    }
}
