using Microsoft.EntityFrameworkCore;
using WebFinal.Models;

namespace WebFinal.Services
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly MainpageDbContext _mainpageDbContext;

        public PlaylistRepository(MainpageDbContext mainpageDbContext)
        {
            _mainpageDbContext = mainpageDbContext;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylists()
        {
           return await _mainpageDbContext.Playlists.ToListAsync(); 
        }

        public async Task<bool> CreatePlaylist(Playlist playlist)
        {
            _mainpageDbContext.Playlists.Add(playlist);

            return (await _mainpageDbContext.SaveChangesAsync() >= 0);
        }

        public async Task<Playlist?> GetPlaylist(int playlistId, bool incluyeCancion)
        {
            if (incluyeCancion)
            {
                return await _mainpageDbContext.Playlists.Include(p=>p.Canciones).Where(p => p.Id == playlistId).FirstOrDefaultAsync();
            }

            return await _mainpageDbContext.Playlists.Where(p => p.Id == playlistId).FirstOrDefaultAsync();
        }

        public async Task<bool> PlaylistExistAsync(int playlistId)
        {
            return await _mainpageDbContext.Playlists.AnyAsync(c => c.Id == playlistId);
        }

        public async Task<bool> SavesChangesAsync()
        {
            return (await _mainpageDbContext.SaveChangesAsync() >= 0);
        }
        //canciones cositas 


        public async Task<IEnumerable<Cancion>> GetCanciones(int playlistId)
        {
            return await _mainpageDbContext.Canciones.Where(p => p.PlaylistId == playlistId).ToListAsync();
        }

        public async Task AddCancion(int playlistId, Cancion cancion)
        {

            var playlist = await GetPlaylist(playlistId, false);
            
            if (playlist != null)
            {
                playlist.Canciones.Add(cancion);
            }

        }

        public async Task<Cancion?> GetCancion(int playlistId, int cancionId)
        {
            return await _mainpageDbContext.Canciones.Where(c => c.Id == cancionId && c.PlaylistId == playlistId).FirstOrDefaultAsync();
        }
    }
}
