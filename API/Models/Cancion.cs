using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Cancion
    {
        public Cancion()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int CancionId { get; set; }
        public string Nombre { get; set; }
        public int AlbumId { get; set; }
        public int GeneroId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
