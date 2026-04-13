using CRUDProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUDProject.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions<MVCDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}