using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Cancion = new HashSet<Cancion>();
        }

        public int GeneroId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cancion> Cancion { get; set; }
    }
}
