using CarritoCompras.Modelo;
using CarritoCompras.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarritoCompras.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageDespacho : ContentPage
	{
        public List<Departamento> oListaDepartamento { get; set; }
        public List<Provincia> oListaProvincia { get; set; }
        public List<Distrito> oListaDistrito { get; set; }
        public List<Tienda> oListaTienda { get; set; }

        public ObservableCollection<Bolsa> oListaGlobalBolsa = new ObservableCollection<Bolsa>();

        public PageDespacho (ObservableCollection<Bolsa> oListaBolsa,bool delivery)
		{
			InitializeComponent ();
            if (delivery)
            {
                this.Title = "Despacho";
                obtenerDepartamento();
                ContentDelivery.IsVisible = true;
            }
            else{
                this.Title = "Retiro";
                obtenerTiendas();
                ContentRetiro.IsVisible = true;
            }

            oListaGlobalBolsa = oListaBolsa;

        }

        private async void obtenerTiendas()
        {
            oListaTienda = await ApiServiceFirebase.ObtenerTiendas();
            ListViewTiendas.ItemsSource = oListaTienda;
        }

        private async void obtenerDepartamento()
        {
            oListaDepartamento = await ApiServiceFirebase.ObtenerDepartamentos();
            pickerDepartamento.ItemsSource = oListaDepartamento;
        }

        private async void PickerDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Departamento oDepartamento = (Departamento)((Picker)sender).SelectedItem;
            oListaProvincia = await ApiServiceFirebase.ObtenerProvincias(oDepartamento.nombredepartamento);
            pickerProvincia.ItemsSource = oListaProvincia;
        }

        private async void PickerProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provincia oProvincia = (Provincia)((Picker)sender).SelectedItem;
            oListaDistrito = await ApiServiceFirebase.ObtenerDistrito(oProvincia.nombreprovincia);
            pickerDistrito.ItemsSource = oListaDistrito;
        }

        

        private void SearchTiendas_TextChanged(object sender, TextChangedEventArgs e)
        {
            var BusquedaResultado = oListaTienda.Where(x => x.titulo.ToLower().Contains(SearchTiendas.Text.Trim().ToLower()));
            ListViewTiendas.ItemsSource = BusquedaResultado;
        }

        //METODO QUE SE DIRIGEN AL PAGO

        private async void BtnContinuar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPersonaContacto.Text) || String.IsNullOrWhiteSpace(txtDireccion.Text) || String.IsNullOrWhiteSpace(txtCelular.Text) ||
                pickerDepartamento.SelectedIndex == -1 || pickerProvincia.SelectedIndex == -1 || pickerDistrito.SelectedIndex == -1)
            {
                await DisplayAlert("Mensaje", "Complete todos los campos", "Ok");
                return;
            }

            Despacho oDespacho = new Despacho() {
                personaContacto = txtPersonaContacto.Text,
                direccion = txtDireccion.Text,
                departamento = ((Departamento)pickerDepartamento.SelectedItem).nombredepartamento,
                provincia = ((Provincia)pickerProvincia.SelectedItem).nombreprovincia,
                distrito = ((Distrito)pickerDistrito.SelectedItem).nombredistrito,
                celular = txtCelular.Text
            };

            Compra oCompra = new Compra()
            {
                fechaCompra = DateTime.Now.ToString("dd/MM/yyyy"),
                tipoEntrega = "despacho",
                oListaBolsa = oListaGlobalBolsa,
                oDepacho = oDespacho,
                oTienda = null
            };

            await Navigation.PushAsync(new PagePago(oCompra));
        }

        private async void ListViewTiendas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Tienda oTienda = (Tienda)e.Item;

            Compra oCompra = new Compra()
            {
                fechaCompra = DateTime.Now.ToString("dd/MM/yyyy"),
                tipoEntrega = "retiro",
                oListaBolsa = oListaGlobalBolsa,
                oTienda = oTienda,
                oDepacho = null
            };

            await Navigation.PushAsync(new PagePago(oCompra));
        }
    }
}