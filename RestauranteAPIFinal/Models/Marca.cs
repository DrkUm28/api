using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteAPIFinal.Models
{
    public class Marca
    {
        public int cod_marca { get; set; }

        public string nombre { get; set; }

        public int cod_nacionalidad { get; set; }

        public string descripcion { get; set; }

        public int empresa { get; set; }

    }
}