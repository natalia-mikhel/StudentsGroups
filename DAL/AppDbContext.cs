using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext, IDbContext
    {
        // DbSet<Enity> Entities { get; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}