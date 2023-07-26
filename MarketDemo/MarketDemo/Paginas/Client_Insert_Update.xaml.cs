using Java.Net;
using MarketDemo.Models;
using MarketDemo.Paginas;
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
    public partial class Client_Insert_Update : ContentPage
    {
        public Client_Insert_Update()
        {
            InitializeComponent();
        }
        private string Url = "https://cuentas2.azurewebsites.net/api/cliente/";
        private Cliente[] Clientes { get; set; }
       
        private void Btn_Update(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");

                var datos = new Cliente
                {
                    cedulaCli = cedula.Text,
                    nombresCli = nombre.Text,
                    totalPagarCre = float.Parse(totalPa.Text),
                    debe = float.Parse(debe.Text),
                    saldo = float.Parse(saldo.Text)
                };
                var json = JsonConvert.SerializeObject(datos);

                try
                {
                    var response = wc.UploadString(Url, "POST", json);
                    lblDatos.IsVisible = true;
                    lblDatos.Text = "Insert_Update correcto";
                }
                
                catch (WebException)
                {
                    lblDatos.IsVisible = true;
                    lblDatos.Text = "Error al actualizar";
                }
               
            }
        }
        private void Btn_Delete(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                wc.UploadString(Url + "/" + cedula.Text, "DELETE", "");
                lblDatos.Text = "Datos eliminados correctamente";
                cedula.Text = "";
                nombre.Text = "";
                totalPa.Text = "";
                saldo.Text = "";
                debe.Text = "";
            }
        }
    }
}