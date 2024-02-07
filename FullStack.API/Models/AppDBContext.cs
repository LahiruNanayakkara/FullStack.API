using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public AppDBContext(DbContextOptions options) : base(options)
        { }
    }
}
