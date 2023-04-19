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
	public partial class PagePopup : ContentPage
	{
		public PagePopup ()
		{
			InitializeComponent ();
		}

        private void BtnCerrarModal_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}