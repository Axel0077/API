using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Album
    {
        public Album()
        {
            Cancion = new HashSet<Cancion>();
        }

        public int AlbumId { get; set; }
        public string Titulo { get; set; }
        public int ArtistaId { get; set; }

        public virtual Artista Artista { get; set; }
        public virtual ICollection<Cancion> Cancion { get; set; }
    }
}
