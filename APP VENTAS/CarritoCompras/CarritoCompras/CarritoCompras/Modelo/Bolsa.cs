using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoCompras.Modelo
{
    public class Bolsa
    {
        public string idbolsa { get; set; }
        public int cantidad { get; set; }
        public string categoria { get; set; }
        public float montoTotal { get; set; }
        public Producto producto { get; set; }
    }
}
