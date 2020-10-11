using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public int? JefeDirecto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
