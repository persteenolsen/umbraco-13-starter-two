using MvcUmbraco.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcUmbraco.Data
{
    public class MvcAppDbContext:DbContext
    {
        public MvcAppDbContext(DbContextOptions<MvcAppDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
