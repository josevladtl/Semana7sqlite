using SQLite;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Semana7sqlite.Modelos;



namespace Semana7sqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {

        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Datos();
        }

        public async void Datos() {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
           ListaEstudiantes.ItemsSource = tablaEstudiante;

        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            var IdSeleccionado = Convert.ToInt32(item);//

            var nombre = Obj.Nombre;
            try
            {
                Navigation.PushAsync(new Elemento(IdSeleccionado, nombre ));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        

        }
    }
