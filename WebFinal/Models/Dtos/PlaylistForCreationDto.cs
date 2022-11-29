using System.ComponentModel.DataAnnotations;

namespace WebFinal.Models.Dtos
{
    public class PlaylistForCreationDto
    {
        [Required(ErrorMessage = "you should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(200)]
        public string? Descripcion { get; set; }

        public ICollection<CancionDto> Canciones { get; set; } = new List<CancionDto>();
    }

}
