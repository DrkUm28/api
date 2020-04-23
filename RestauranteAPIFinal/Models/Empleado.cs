using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Empleado
    { 
        public int cod_empleado { get; set; }
        public int cedula { get; set; }

        public string nombre { get; set; }

        public string primerApellido { get; set; }

        public string segundoApellido { get; set; }

        public int telefono1 { get; set; }

        public int telefono2 { get; set; }

        public int cod_puesto { get; set; }

        public int cod_nacionalidad { get; set; }

        public int cod_restaurante { get; set; }

    }
}