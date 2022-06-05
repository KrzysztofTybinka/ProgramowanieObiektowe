using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Projekt
{
    /// <summary>
    /// Connection with database.
    /// </summary>
    public class BloggingContext : DbContext
    {
        public DbSet<Guests> Guests { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<ToReserve> ToReserve { get; set; }
        public DbSet<Reservations> Reservations { get; set; }

        public string ConnectionString { get; }

        public BloggingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reservations>().HasKey(table => new {
                table.ToReserve,
                table.Guest
            });
        }
    }

    /// <summary>
    /// Guests table.
    /// </summary>
    public class Guests
    {
        [Key]
        public int Guest_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string? Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }

    /// <summary>
    /// Categories table.
    /// </summary>
    public class Categories
    {
        [Key]
        public string? Category_Id { get; set; }
    }

    /// <summary>
    /// Fields table.
    /// </summary>
    public class Fields
    {
        [Key]
        public int Field_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
    }

    /// <summary>
    /// To Reserve table.
    /// </summary>
    public class ToReserve
    {
        [Key]
        public int ToReserve_Id { get; set; }
        [Required]
        public int Field { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Reservations table.
    /// </summary>
    public class Reservations
    {
        public int Guest { get; set; }
        public int ToReserve { get; set; }
    }
}
