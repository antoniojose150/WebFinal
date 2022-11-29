using WebFinal.Models;

namespace WebFinal.Services
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetPlaylists();

        Task<Playlist?> GetPlaylist(int playlistId, bool incluyeCancion);

        Task <bool>CreatePlaylist(Playlist playlist);

        Task<bool> PlaylistExistAsync(int playlistId);

        Task<bool> SavesChangesAsync();
        //canciones cositas
        Task AddCancion(int playlistId, Cancion cancion);

        Task<IEnumerable<Cancion>> GetCanciones(int playlistId);

        Task <Cancion?> GetCancion(int playlistId,int cancionId);


    }
}
