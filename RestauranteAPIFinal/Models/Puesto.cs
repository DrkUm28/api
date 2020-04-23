using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Puesto
    {
        public int cod_puesto { get; set; }
        public string nombre { get; set; }

        public bool interno_restaurante { get; set; }

        public bool externo_restaurante { get; set; }

        public int cod_rol { get; set; }
    }
}