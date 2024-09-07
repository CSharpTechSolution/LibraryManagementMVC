using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Implementation;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Context;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Book>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Role>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<User>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Borrow>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Reservation>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Library>()
       .HasKey(a => a.Id);
        modelBuilder.Entity<UserRole>()
       .HasKey(a => a.Id);

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Borrow> Borrows { get; set; }
    public DbSet<Library> Library { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

}

