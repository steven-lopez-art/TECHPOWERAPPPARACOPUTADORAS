using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TECHPOWERAPP
{
    public class Compra
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string MetodoPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public string MetodoEntrega { get; set; }
        public string Productos { get; set; } // Almacenar los productos como una cadena JSON
        public decimal Total { get; set; }
    }
}
