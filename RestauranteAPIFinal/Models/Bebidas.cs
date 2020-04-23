using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Bebidas
    {
        public int cod_bebida { get; set; }
        public string nombre { get; set; }

        public int tipo { get; set; }

        public int nacionalidad { get; set; }

        public int marca { get; set; }

        public double precio_unitario { get; set; }

        public double precio_botella { get; set; }

        public int cantidad { get; set; }

        public int anio_cosecha { get; set; }

        public string descripcion { get; set; }

        public int proveedor { get; set; }

        public int restaurante { get; set; }
    }
}