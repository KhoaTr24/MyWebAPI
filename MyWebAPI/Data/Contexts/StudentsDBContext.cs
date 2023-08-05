using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Entities;

namespace MyWebAPI.Data.Contexts
{
    public class StudentsDBContext : DbContext
    {
        public StudentsDBContext(DbContextOptions<StudentsDBContext> options) : base(options) 
        { 
        
        }

        #region
        public DbSet<Students> Students { get; set; }
        public DbSet<Diem> Diem { get; set; }
        #endregion
    }
}
