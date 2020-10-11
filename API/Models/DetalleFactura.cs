using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }
        public int FacturaId { get; set; }
        public int CancionId { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int Cantidad { get; set; }

        public virtual Cancion Cancion { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
