using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Bitacora
    {
        public int cod_bitacora { get; set; }

        public string usuario { get; set; }

        public DateTime fecha_hora_accion { get; set; }

        public string descripcion_accion { get; set; }

        public string detalle_accion { get; set; }

        public int restaurante { get; set; }
 
    }
}