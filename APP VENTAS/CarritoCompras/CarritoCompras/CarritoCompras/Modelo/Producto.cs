using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoCompras.Modelo
{
    public class Producto
    {
        public string idproducto { get; set; }
        public string descripcion { get; set; }
        public string detalle { get; set; }
        public string imagen { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public int stock { get; set; }
    }
}
