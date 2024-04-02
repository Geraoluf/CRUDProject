using CRUDProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUDProject.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Medarbejder> Medarbejder { get; set; }
    }
    


    
}
