using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Semana7sqlite.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Sqlclient))]
namespace Semana7sqlite.Droid
{
    public class Sqlclient : DataBase
    {
        public SQLite.SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "uisrael.db3");

            return new SQLiteAsyncConnection(path);

        }
    }
}