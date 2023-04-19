using CarritoCompras.Modelo;
using CarritoCompras.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarritoCompras.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageProductos : ContentPage
	{
        private string nombreGlobalCategoria;
        public List<Producto> oListaProductos;
		public PageProductos (string nombreCategoria)
		{
			InitializeComponent ();
            ObtenerProductos(nombreCategoria);
            nombreGlobalCategoria = nombreCategoria;
            this.Title = nombreCategoria;
		}

        private async void ObtenerProductos(string nombreCategoria)
        {
            Dictionary<string,Producto> oObjeto = new Dictionary<string, Producto>();
            oObjeto = await ApiServiceFirebase.ObtenerProductos(nombreCategoria);

            List<Producto> oListaTemp = new List<Producto>();

            if (oObjeto.Count > 0)
            {
                foreach (KeyValuePair<string, Producto> item in oObjeto)
                {
                    oListaTemp.Add(new Producto()
                    {
                        idproducto = item.Key,
                        descripcion = item.Value.descripcion,
                        detalle = item.Value.detalle,
                        imagen = item.Value.imagen,
                        nombre = item.Value.nombre,
                        precio = item.Value.precio,
                        stock = item.Value.stock

                    });
                }
                oListaProductos = oListaTemp;
            }

            cvListaProductos.ItemsSource = oListaProductos;
        }

        private async void CvListaProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Producto oProducto = (Producto)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new PageDetalleProducto(oProducto, nombreGlobalCategoria));
            //((CollectionView)sender).SelectedItem = null;
        }
    }
}