using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class LimpiezaHigiene
    {
        public int cod_limpieza { get; set; }

        public int cod_restaurante { get; set; }

        public string nombre { get; set; }

        public int cod_marca { get; set; }

        public string descripcion { get; set; }

        public int cantidad { get; set; }

        public bool liquido { get; set; }

        public string tipo { get; set; }

        public string cantidadMedida { get; set; }

        public int cod_unidadMedida { get; set; }

        public int proveedor { get; set; }
    }
}
