using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDenuncias.model
{
    public class DenunciaModel
    {
        public int id { get; set; }
        public DateTime fechaRegistro { get; set; }

        public DateTime fechaFin { get; set; }

        public string fechaSuceso { get; set; }

        public string descripcion { get; set; }

        public int statusFK { get; set; }

        public int tipoDenunciaFK { get; set; }

        public int usuarioFK { get; set; }
    }
}