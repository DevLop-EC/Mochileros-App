using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using Mochileros2App.Models;
using System.Threading.Tasks;

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

        public async Task<int> RegisterUserAsync(Users user)
        {
            return await Connection.InsertAsync(user);
        }

        // login user
        public async Task<bool> LoginUserAsync(string email, string password)
        {
            var user = await Connection.Table<Users>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
