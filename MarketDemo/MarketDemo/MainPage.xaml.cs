using Java.Net;
using MarketDemo.Interface;
using MarketDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MarketDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private string Url = "https://prueba77.azurewebsites.net/user";


        // private Models.Login[] Ctabancarias { get; set; }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {

            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "Application/json");
                var datos = new Models.Login
                {
                    correo = UsernameEntry.Text,
                    clave = PasswordEntry.Text,
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                try
                {
                    Console.WriteLine(Url + "/autenticar");
                    Console.WriteLine(json);
                    var response = wc.UploadString(Url + "/autenticar", "POST", json);
                    var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseLogin>(response);
                    
                    if (jsonResponse.codigo == "0")
                    {
                        var toke = jsonResponse.datos;
                        var mensaje= jsonResponse.mensaje;
                        Navigation.PushAsync(new Paginas.Lista_libros());
                    }
                    else
                    {
                        var mensaje = jsonResponse.mensaje;
                        DisplayAlert("Error", "Credenciales incorrectas. Por favor, intenta de nuevo.", "OK");
                    }
                    //Console.WriteLine(toke);
                }
                catch (WebException)
                {
                    Console.WriteLine("hola");
                }
            }
        }
        async void OnLogin(System.Object sender, System.EventArgs e)
        {
           await Navigation.PushAsync(new Paginas.RegistroUsers());
        }
    }
}