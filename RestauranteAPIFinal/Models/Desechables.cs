using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Desechables
    {
        public int cod_empaque { get; set; }

        public int cod_restaurante { get; set; }

        public string nombre { get; set; }

        public int cod_marca { get; set; }

        public string descripcion { get; set; }

        public int cantidad { get; set; }

        public int proveedor { get; set; }
    }
}