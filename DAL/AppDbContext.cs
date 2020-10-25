using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext, IDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        
        public DbSet<StudentGroup> StudentGroups { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Identifier)
                .IsUnique();
            
            modelBuilder.Entity<StudentGroup>()
                .HasKey(t => new { t.StudentId, t.GroupId });
 
            modelBuilder.Entity<StudentGroup>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentGroups)
                .HasForeignKey(sc => sc.StudentId);
 
            modelBuilder.Entity<StudentGroup>()
                .HasOne(sc => sc.Group)
                .WithMany(c => c.StudentGroups)
                .HasForeignKey(sc => sc.GroupId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}