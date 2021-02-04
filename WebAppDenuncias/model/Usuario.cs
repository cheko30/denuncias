using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDenuncias.model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string password { get; set; }

        public int rolFK { get; set; }
    }
}