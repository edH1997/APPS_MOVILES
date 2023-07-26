using MarketDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketDemo.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insert_UpdateLibros : ContentPage
    {
        public Insert_UpdateLibros()
        {
            InitializeComponent();
        }
        private string apiUrl = "https://aappmoviles.azurewebsites.net/libro/libro";
        private Libro[] Libros { get; set; }


        private void OnAgregarLibroClicked(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Libro
                {
                    Nombre = nombreEntry.Text,
                    Anio = int.Parse(anioEntry.Text),
                    Autor = autorEntry.Text,
                    Urlimg = urlimgEntry.Text
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                wc.UploadString(apiUrl, "POST", json);
                lblDatos.Text = "DATOS INSERTADOS CON EXITO";

            }
        }
    }
}