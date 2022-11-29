using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFinal.Models
{
    public class Playlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string? Descripcion { get; set; }

        public ICollection<Cancion> Canciones { get; set; } = new List<Cancion>();

        public Playlist(string name)
        {
            Name = name;
        }

    }
}
