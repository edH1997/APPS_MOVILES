using MarketDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketDemo.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista_libros : ContentPage
    {
        public Lista_libros()
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
                    string apiUrl = "https://aappmoviles.azurewebsites.net/libro/libro"; // Reemplaza esta URL por la URL real de la API
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        List<Libro> librosList = JsonConvert.DeserializeObject<List<Libro>>(jsonContent);

                        int rowIndex = 0;

                        // Cabeceras de la tabla
                        TablaGrid.Children.Add(new Label { Text = "Nombre", FontAttributes = FontAttributes.Bold }, 0, rowIndex);
                        TablaGrid.Children.Add(new Label { Text = "Año", FontAttributes = FontAttributes.Bold }, 1, rowIndex);
                        TablaGrid.Children.Add(new Label { Text = "Autor", FontAttributes = FontAttributes.Bold }, 2, rowIndex);
                        TablaGrid.Children.Add(new Label { Text = "UrlImg", FontAttributes = FontAttributes.Bold }, 3, rowIndex);



                        rowIndex++;

                        foreach (var libro in librosList)
                        {
                            TablaGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                            // Filas de datos
                            TablaGrid.Children.Add(new Label { Text = libro.Nombre }, 0, TablaGrid.RowDefinitions.Count - 1);
                            TablaGrid.Children.Add(new Label { Text = libro.Anio.ToString() }, 1, TablaGrid.RowDefinitions.Count - 1);
                            TablaGrid.Children.Add(new Label { Text = libro.Autor }, 2, TablaGrid.RowDefinitions.Count - 1);


                            var image = new Image
                            {
                                Source = new UriImageSource { Uri = new Uri(libro.Urlimg) },
                                Aspect = Aspect.AspectFit


                            };
                            TablaGrid.Children.Add(image, 3, TablaGrid.RowDefinitions.Count - 1);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores
                await DisplayAlert("Error", "No se pudo obtener la lista de libros.", "OK");
            }
        }


        private async void OnButtonClicked(object sender, EventArgs e)
        {
            // navegar a la página OtraPagina
            await Navigation.PushAsync(new Paginas.Insert_UpdateLibros());
        }
       

       private async void Btn_irClient(object sender, EventArgs e)
        {
            // navegar a la página OtraPagina
            await Navigation.PushAsync(new Paginas.ListaClientes());
        }
    }


}