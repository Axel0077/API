using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Factura = new HashSet<Factura>();
        }

        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int SoporteId { get; set; }

        public virtual Empleado Soporte { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
