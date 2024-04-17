using BACKEND.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Persistence
{
    public class SafariDbContext: IdentityDbContext<User>
    {
        public SafariDbContext(DbContextOptions<SafariDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<EventoToUser> EventosToUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

