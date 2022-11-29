namespace WebFinal.Models.Dtos
{
    public class PlaylistDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public string? Descripcion { get; set; }

        public ICollection<CancionDto> Canciones { get; set; } = new List<CancionDto>();
    }
}
