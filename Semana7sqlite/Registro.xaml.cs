using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Semana7sqlite.Modelos;
using System.Runtime.CompilerServices;

namespace Semana7sqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {

        private SQLiteAsyncConnection con;

        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
                con.InsertAsync(datosRegistro);

                DisplayAlert("Mensaje", "Ingreso Correcto", "Cerrar");

                txtUsuario.Text = "";
                txtNombre.Text = "";
                txtContrasena.Text = "";
            }
            catch (Exception ex)
            {

                DisplayAlert("Mensaje", ex.Message, "Cerrar");
            }
        }
        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}
           