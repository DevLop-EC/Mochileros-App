using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace Mochileros2App.Models
{


    public class Auth
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

    }
}
