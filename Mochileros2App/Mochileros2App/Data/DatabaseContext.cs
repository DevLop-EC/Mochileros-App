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
        public static SQLiteAsyncConnection Connection;


        public DatabaseContext(string path)
        {

            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTablesAsync<Auth, Opinions>().Wait();
            Connection.CloseAsync();

        }

        public async Task<int> RegisterUserAsync(Auth user)
        {
            return await Connection.InsertAsync(user);
        }

        // login user
        public async Task<bool> LoginUserAsync(string email, string password)
        {
            var user = await Connection.Table<Auth>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<int> InsertOpinionAsync(Opinions opinions)
        {
            if (opinions is null)
            {
                throw new ArgumentNullException(nameof(opinions));
            }

            return await Connection.InsertAsync(opinions);
        }

        public async Task<List<Opinions>> GetOpinionsAsync()
        {
            var opinions = Connection.Table<Opinions>().ToListAsync();

            if (opinions is null)
            {
                throw new ArgumentNullException(nameof(opinions));
            }


            return await opinions;
        }


        public async Task<int> UpdateOpinionsAsync(Opinions opinions)
        {

            if (opinions is null)
            {
                throw new ArgumentNullException(nameof(opinions));
            }

            return await Connection.UpdateAsync(opinions);
        }

        public async Task<int> DeleteOpinionsAsync(Opinions opinions)
        {
            if (opinions is null)
            {
                throw new ArgumentNullException(nameof(opinions));
            }

            return await Connection.DeleteAsync(opinions);
        }




    }
}
