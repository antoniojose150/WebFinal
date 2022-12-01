using WebFinal.Models;

namespace WebFinal.Models.Dtos
{
    public class CancionFroCreationDto
    {

        public string Name { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public int PlaylistId { get; set; }

        public PlaylistDto? Playlist { get; set; } = default!;
    }
}
