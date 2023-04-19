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
	public partial class PageCompras : ContentPage
	{
        public List<Compra> oListaCompra { get; set; }
        public PageCompras ()
		{
			InitializeComponent ();
            ObtenerCompra();

        }

        private async void ObtenerCompra()
        {
            List<Compra> oObjecto = await ApiServiceFirebase.ObtenerCompra();

            if (oObjecto != null)
            {
                oListaCompra = oObjecto;
                ListViewCompra.ItemsSource = oObjecto;
            }

        }

    }
}