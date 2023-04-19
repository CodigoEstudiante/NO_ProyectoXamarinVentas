using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoCompras.Modelo
{
    public class DetallePago
    {
        public string numeroTarjeta { get; set; }
        public string fechaExpiracion { get; set; }
        public string codigoCVV { get; set; }
        public string email { get; set; }
    }
}
