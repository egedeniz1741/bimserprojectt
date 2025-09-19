
using Microsoft.EntityFrameworkCore;
using BimserProject.Core.Entities;


namespace BimserProject.Data.contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<WatchedFilm> WatchedFilms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<WatchedFilm>()
                .HasKey(wf => new { wf.UserId, wf.FilmId });

            
            modelBuilder.Entity<WatchedFilm>()
                .HasOne(wf => wf.User)
                .WithMany(u => u.WatchedFilms)
                .HasForeignKey(wf => wf.UserId);

            modelBuilder.Entity<WatchedFilm>()
                .HasOne(wf => wf.Film)
                .WithMany(f => f.WatchedByUsers)
                .HasForeignKey(wf => wf.FilmId);
        }

    }
}
