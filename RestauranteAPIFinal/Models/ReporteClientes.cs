using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class ReporteClientes
    {
        public int  cod_reporteCliente { get; set; }

        public int cod_cliente { get; set; }

        public string descripcion { get; set; }

        public int restaurante { get; set; }

        public  int cod_factura { get; set; }
    }
}