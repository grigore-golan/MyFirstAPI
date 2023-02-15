using Microsoft.EntityFrameworkCore;
using UniApi.Models;

namespace UniApi.Data
{
    public class DecanDbContext : DbContext
    {
        public DecanDbContext(DbContextOptions<DecanDbContext> options) : base(options)
        {
        }

        public DbSet<Decan> Decani { get; set; }
    }
}
