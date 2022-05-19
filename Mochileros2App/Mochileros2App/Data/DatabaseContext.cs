using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using Mochileros2App.Models;

namespace Mochileros2App.Data
{
    public class DatabaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }

        public DatabaseContext(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<Users>().Wait();

        }
    }
}
