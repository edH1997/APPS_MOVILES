using System;
using System.Collections.Generic;
using System.Text;

namespace MarketDemo.Models
{
    internal class RegistroUser
    {
        public bool activo { get; set; }
        public string codigo { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
    }

}
