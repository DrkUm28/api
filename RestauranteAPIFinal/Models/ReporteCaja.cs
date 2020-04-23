using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class ReporteCaja
    {
        public int cod_reporteCaja { get; set; }

        public int cod_factura { get; set; }
        
        public int cod_caja { get; set; }

        public int factura { get; set; }
    }
}