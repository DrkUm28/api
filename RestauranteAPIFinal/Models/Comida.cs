using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Comida
    {
        public int cod_comida { get; set; }

        public string nombre { get; set; }

        public double precio { get; set; }

        public int cod_tipoComestible { get; set; }

        public int cod_unidadMedida { get; set; }

        public string detalle { get; set; }

        public string ingredientes { get; set; }

        public int linea { get; set; }

        public int clase { get; set; }

        public bool es_bufet { get; set; }

        public bool es_especialidad { get; set; }

        public int restaurante { get; set; } 
    }
}