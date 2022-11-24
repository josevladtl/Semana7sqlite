using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Semana7sqlite.Modelos;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7sqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {

        public int idSel;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> borrar;
        IEnumerable<Estudiante> actualizar;

        public Elemento(int id, string nombre)
        {
            InitializeComponent();
            idSel = id;
            con = DependencyService.Get<DataBase>().GetConnection();
            txtNombre.Text = nombre;

        }
        public static IEnumerable<Estudiante> borrar1(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Delete from Estudiante Where id = ?", id);

        }
        public static IEnumerable<Estudiante> actualizar1(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("Update Estudiante set Nombre =?, Usuario=?, contrasena=? where id=?", nombre, usuario, contrasena, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                actualizar = actualizar1(db, idSel, txtNombre.Text, txtUsuario.Text, txtContrasena.Text);
                DisplayAlert("Mensaje", "Actualizado", "OK");
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);
            borrar = borrar1(db, idSel);
            DisplayAlert("Mensaje", "Eliminado", "OK");


            Navigation.PushAsync(new ConsultaRegistro());
        }
    }
}