using System.ComponentModel.DataAnnotations;
namespace WebFinal.Models.Dtos
{
    public class PlaylistWithoutCancionesDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
    }
}
