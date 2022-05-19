using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mochileros2App.Models
{
    public class Opinions
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Opinion { get; set; }

        public int IdUser { get; set; }
        public DateTime Date { get; set; }
    }
}
