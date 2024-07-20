using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Task1.Models;

namespace Task1.Data
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EnterNumber> EnterNumbers { get; set; }
        
    }
}
