using Java.Net;
using MarketDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace MarketDemo.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaClientes : ContentPage
    {
        public ListaClientes()
        {
            InitializeComponent();
            CargarDatosLibros();
        }

        public async void CargarDatosLibros()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string apiUrl = "https://cuentas2.azurewebsites.net/api/cliente"; // Reemplaza esta URL por la URL real de la API
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        List<Cliente> clientesList = JsonConvert.DeserializeObject<List<Cliente>>(jsonContent);

                        int rowIndex = 0;

                        // Cabeceras de la tabla
                        TablaGrid.Children.Add(new Label { Text = "Cedula", FontAttributes = FontAttributes.Bold }, 0, rowIndex);
                        TablaGrid.Children.Add(new Label { Text = "Nombre", FontAttributes = FontAttributes.Bold }, 1, rowIndex);
                        //TablaGrid.Children.Add(new Label { Text = "Total_Pagar", FontAttributes = FontAttributes.Bold }, 2, rowIndex);
                        TablaGrid.Children.Add(new Label { Text = "Saldo", FontAttributes = FontAttributes.Bold }, 2, rowIndex);
                        TablaGrid.Children.Add(new Label { Text = "Debe", FontAttributes = FontAttributes.Bold }, 3, rowIndex);


                        rowIndex++;

                        foreach (var cliente in clientesList)
                        {
                            TablaGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                            // Filas de datos
                            TablaGrid.Children.Add(new Label { Text = cliente.cedulaCli }, 0, rowIndex);
                            TablaGrid.Children.Add(new Label { Text = cliente.nombresCli }, 1, rowIndex);
                            //TablaGrid.Children.Add(new Label { Text = cliente.totalPagarCre.ToString() }, 2, rowIndex);
                            TablaGrid.Children.Add(new Label { Text = cliente.saldo.ToString() }, 2, rowIndex);
                            TablaGrid.Children.Add(new Label { Text = cliente.debe.ToString() }, 3, rowIndex);
                            rowIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores
                await DisplayAlert("Error", "No se pudo obtener la lista de clientes.", "OK");
            }
        }
        private void Btn_Insert(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.Client_Insert_Update());

        }
    }
}