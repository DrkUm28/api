using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Restaurante
    {
        public int cod_restaurante { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public bool activo { get; set; }
        public int cant_clientes { get; set; }
        public string especialidad { get; set; }
    }
}