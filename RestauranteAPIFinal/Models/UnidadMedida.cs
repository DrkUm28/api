using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class UnidadMedida
    {
        public int cod_unidadMedida { get; set; }

        public string unidad_medida { get; set; }

        public int escala { get; set; }

        public string tipo_unidad { get; set; }
        public string simbologia { get; set; }


    }
}