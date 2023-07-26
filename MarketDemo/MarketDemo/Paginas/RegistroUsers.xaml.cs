using Java.Net;
using MarketDemo.Models;
using Newtonsoft.Json;
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
    public partial class RegistroUsers : ContentPage
    {
        public RegistroUsers()
        {
            InitializeComponent();
        }
        private string Url = "https://prueba77.azurewebsites.net/user/users";
      //  private RegistroUsers[] RegistroUserss { get; set; }
        private void Btn_Update(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");

                var datos = new RegistroUser
                {
                    activo = bool.Parse(activo.Text),
                    codigo = codigo.Text,
                    apellidos = apellidos.Text,
                    nombres= nombres.Text,
                    correo = correo.Text,
                    clave= clave.Text,
                };
                var json = JsonConvert.SerializeObject(datos);

                try
                {
                    var response = wc.UploadString(Url, "POST", json);
                    lblDatos.IsVisible = true;
                    lblDatos.Text = "Insert correcto";
                }

                catch (WebException)
                {
                    lblDatos.IsVisible = true;
                    lblDatos.Text = "Error al actualizar";
                }

            }
        }
    }
}