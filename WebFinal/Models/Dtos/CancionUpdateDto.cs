using System.ComponentModel.DataAnnotations;

namespace WebFinal.Models.Dtos
{
    public class CancionUpdateDto
    {
        [Required(ErrorMessage = "you should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Descripcion { get; set; }
    }
}
