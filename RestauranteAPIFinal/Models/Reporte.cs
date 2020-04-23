using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Reporte
    {
        public int cod_caja { get; set; }

        public DateTime fecha_hora { get; set; }

        public string descripcion_accion { get; set; }

        public double monto_dinero { get; set; }

        public double apertura_caja { get; set; }

        public double cierre_caja { get; set; }

        public int restaurante { get; set; }
    }
}