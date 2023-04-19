using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarritoCompras.Modelo
{
    public class Compra
    {
        public string tipoEntrega { get; set; }
        public string fechaCompra { get; set; }
        public float precioTotal { get; set; }
        public ObservableCollection<Bolsa> oListaBolsa { get; set; }
        public Tienda oTienda { get; set; }
        public Despacho oDepacho { get; set; }
        public DetallePago oDetallePago { get; set; }
    }
}
