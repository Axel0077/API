using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
