using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHPOWERAPP.Login
{
    [Table("categoria")]
    public class Category
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("nombrecategoria")]
        public string NombreCategoria { get; set; }
        [Column("guardar")]
        public string Guardar { get; set; }
    }
}
