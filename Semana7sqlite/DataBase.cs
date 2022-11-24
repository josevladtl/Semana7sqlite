using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Semana7sqlite
{
   public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
