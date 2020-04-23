using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Mesa
    {
        public int cod_mesa { get; set; }

        public int restaurante { get; set; }
        public string nombre { get; set; }

        public int numero { get; set; }

        public int cantidadSillas { get; set; }
    }
}