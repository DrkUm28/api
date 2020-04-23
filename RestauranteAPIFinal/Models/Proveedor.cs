using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Proveedor
    {
        public int cod_proveedor { get; set; }

        public int cedula { get; set; }

        public DateTime fechaIngreso { get; set;}

        public string nombre { get; set; }

        public string primerApellido { get; set; }

        public string segundoApellido { get; set; }

        public string correo { get; set; }

        public string direccion { get; set; }

        public int telefono_oficina { get; set; }

        public int fax { get; set; }

        public int celular { get; set; }
    }
}