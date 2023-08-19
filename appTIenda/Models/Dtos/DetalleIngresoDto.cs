using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class DetalleIngresoDto
    {
        public string nombreProducto { get; set; }

        public decimal Precio { get; set; }

        public DateTime fechaIngreso { get; set; }

        public int Cantidad { get; set; }

        public string NombreUsuario { get; set; }

        public string nombreCategoria { get; set; }
    }
}
