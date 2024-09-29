using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHPOWERAPP.Login
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), Unique]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
