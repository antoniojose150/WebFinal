using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFinal.Models
{
    public class Cancion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Descripcion { get; set; }

        [ForeignKey("PlaylistId")]
        public Playlist? Playlist { get; set; }
        public int PlaylistId { get; set; }


        public Cancion(string name) => Name = name;
    }
}
