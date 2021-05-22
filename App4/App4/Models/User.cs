using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string userName { get; set; }
        public string name { get; set; }

        public string password { get; set; }

        public string phone { get; set; }
    }
}
