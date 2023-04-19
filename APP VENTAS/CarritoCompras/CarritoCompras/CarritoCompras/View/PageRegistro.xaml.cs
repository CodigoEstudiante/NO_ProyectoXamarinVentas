using AppNotas.Modelo;
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
	public partial class PageRegistro : ContentPage
	{
		public PageRegistro ()
		{
			InitializeComponent ();
		}

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Usuario oUsuario = new Usuario()
            {
                Nombres = txtNombre.Text,
                Apellidos = txtApellido.Text,
                Documento = txtDocumento.Text,
                Email = txtEmail.Text,
                Clave = txtContrasena.Text
            };

            bool respuesta = await ApiServiceAuthentication.RegistrarUsuario(oUsuario);

            if (respuesta)
            {
                await DisplayAlert("Correcto", "Usuario registrado", "Aceptar");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Oops", "No se pudo registrar", "Aceptar");
            }
            


            //var actionSheet = await DisplayActionSheet("Title", "Cancel", "Destruction", "Button1", "Button2", "Button3");

            //switch (actionSheet)
            //{
            //    case "Cancel":

            //        // Do Something when 'Cancel' Button is pressed

            //        break;

            //    case "Destruction":

            //        // Do Something when 'Destruction' Button is pressed

            //        break;
            //    case "Button1":

            //        // Do Something when 'Button1' Button is pressed

            //        break;

            //    case "Button2":

            //        // Do Something when 'Button2' Button is pressed

            //        break;
            //    case "Button3":

            //        // Do Something when 'Button3' Button is pressed

            //        break;

            //}
        }

        private void TapBackArrow_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void TapLabelTerminosCondiciones_Tapped(object sender, EventArgs e)
        {
            popupTerminosCondiciones.IsVisible = true;
            //await Navigation.PushModalAsync(new PagePopup());
        }

        private void BtnCerrarModal_Clicked(object sender, EventArgs e)
        {
            popupTerminosCondiciones.IsVisible = false;
        }
    }
}