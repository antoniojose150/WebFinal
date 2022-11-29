using Microsoft.EntityFrameworkCore;

namespace WebFinal.Models
{
    public class MainpageDbContext : DbContext
    {


        public DbSet<Playlist> Playlists { get; set; } = null!;

        public DbSet<Cancion> Canciones { get; set; } = null!;


        public MainpageDbContext(DbContextOptions<MainpageDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist("linkin park")
                {
                    Id = 1,
                    Descripcion = "linking park lista"
                });
            modelBuilder.Entity<Cancion>().HasData(
                new Cancion("in the end")
                {
                    Id = 1,
                    Descripcion = "cancion buenisima",
                    PlaylistId = 1
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
