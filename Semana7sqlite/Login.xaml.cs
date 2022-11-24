using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semana7sqlite.Modelos;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7sqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage

    {
        private SQLiteAsyncConnection con;

        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante>  SELECT_WHERE (SQLiteConnection db,string usuario,string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where usuario = ? and contrasena = ?", usuario, contrasena);
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());

                }
                else
                {
                    DisplayAlert("Alerta", "Usuario NO existe", "cerrar");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}