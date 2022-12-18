using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        static private UniversityContext universityContextInstance = null;
        static public int count = 0;
        private UniversityContext(DbContextOptions o) : base(o)
        {
            count++;
        }
        static public UniversityContext Instantiate_UniversityContext()
        {
            if (universityContextInstance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionsBuilder.UseSqlite(@"Data Source=W:\Coding\INSAT\CodingGl3\.NET\TP4\2022GL3.NETFrameworkTP4-SQLiteDatabase.db");
                universityContextInstance = new UniversityContext(optionsBuilder.Options);
                return universityContextInstance;
            }
            else
            {
                return universityContextInstance;
            }
        }
    }
}