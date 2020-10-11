using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Artista
    {
        public Artista()
        {
            Album = new HashSet<Album>();
        }

        public int ArtistaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
