using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHPOWERAPP.Login
{
    public class DBService
    {
        private readonly SQLiteAsyncConnection _database;

        public DBService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Producto>().Wait();
            _database.CreateTableAsync<Compra>().Wait();
            // Crear la tabla de productos
            //_database.CreateTableAsync<Category>().Wait();

            // Inicializar el usuario administrador
            InitializeAdmin();

            InitializeProduct();

        }

        private async void InitializeAdmin()
        {
            var admin = await _database.Table<User>().FirstOrDefaultAsync(u => u.IsAdmin);
            if (admin == null)
            {
                // Crear usuario administrador predeterminado
                var defaultAdmin = new User
                {
                    Email = "Administrador",
                    Password = "1234",
                    IsAdmin = true
                };
                await _database.InsertAsync(defaultAdmin);
            }
        }

        public Task<int> RegisterUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return _database.Table<User>().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public Task<List<User>> GetAllUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }


        //-------------------------------------PRODUCTO------------------------------------

        private async void InitializeProduct()
        {
            // Verificar si ya hay productos en la tabla
            var productsCount = await _database.Table<Producto>().CountAsync();
            if (productsCount == 0)
            {
                // Lista de productos predeterminados
                var products = new List<Producto>
        {
            new Producto { Nombre = "Monitor HP M24fwa FHP ", Descripcion = "Monitor de alta definición 1080p", Precio = 239.00m, ImagenURL = "monitor1.png" },
             new Producto { Nombre = "Monitor Gamer Curvado ", Descripcion = "Monitor de alta definición 1080p", Precio = 469.00m, ImagenURL = "monitor2.png" },
             new Producto { Nombre = "Monitor HP", Descripcion = "Monitor de alta definición 1080p", Precio = 329.00m, ImagenURL = "monitor3.png" },
             new Producto { Nombre = "Monitor DELL FHD", Descripcion = "Monitor de alta definición 1080p", Precio = 119.00m, ImagenURL = "monitor4.png" },
             new Producto { Nombre = "Monitor HP FHD", Descripcion = "Monitor de alta definición 1080p", Precio = 180.90m, ImagenURL = "monitor5.png" },
             new Producto { Nombre = "Monitor Gamer Curvado ASUS", Descripcion = "Monitor de alta definición 1080p", Precio = 449.00m, ImagenURL = "monitor6.png" },
             new Producto { Nombre = "Monitor Gamer Curvado HP FHD", Descripcion = "Monitor de alta definición 1080p", Precio = 299.95m, ImagenURL = "monitor7.png" },
             new Producto { Nombre = "Monitor HP M24fw FHP", Descripcion = "Monitor de alta definición 1080p", Precio = 179.00m, ImagenURL = "monitor8.png" },
             new Producto { Nombre = "Monitor Gamer Curvado ", Descripcion = "Monitor de alta definición 1080p", Precio = 189.00m, ImagenURL = "monitor9.png" },
             new Producto { Nombre = "Monitor Gamer Curvado HP", Descripcion = "Monitor de alta definición 1080p", Precio = 579.86m, ImagenURL = "monitor10.png" },
             new Producto { Nombre = "TECLADO ERGONÓMICO", Descripcion = "TAMAÑO:  44.5cm x 15cm", Precio = 45.00m, ImagenURL = "teclado1.png" },
             new Producto { Nombre = "TECLADO INHALÁMRICO", Descripcion = "TAMAÑO:  44.5cm x 15cm", Precio = 30.00m, ImagenURL = "teclado2.png" },
             new Producto { Nombre = "TECLADO GAMER", Descripcion = "TAMAÑO:  44.5cm x 15cm", Precio = 50.00m, ImagenURL = "teclado3.png" },
             new Producto { Nombre = "TECLADO MULTIMEDIA", Descripcion = "TAMAÑO:  44.5cm x 15cm", Precio = 35.00m, ImagenURL = "teclado4.png" },
             new Producto { Nombre = "TECLADO MULTIMEDIA", Descripcion = "TAMAÑO:  44.5cm x 15cm", Precio = 40.00m, ImagenURL = "teclado5.png" },
             new Producto { Nombre = "TECLADO NUMÉRICO", Descripcion = "TAMAÑO:  140 x 85 x 23 cm", Precio = 10.00m, ImagenURL = "teclado6.png" },
             new Producto { Nombre = "TECLADO PLEGABLE", Descripcion = "TAMAÑO: 11.89 x 3.82 x 0.31 cm", Precio = 25.00m, ImagenURL = "teclado7.png" },
             new Producto { Nombre = "TECLADO QWERTY", Descripcion = "TAMAÑO:  44.5cm x 15cm", Precio = 20.00m, ImagenURL = "teclado8.png" },
             new Producto { Nombre = "TECLADO TÁCTIL", Descripcion = "TAMAÑO:  44.5cm x 15cm", Precio = 40.00m, ImagenURL = "teclado9.png" },
             new Producto { Nombre = "TECLADO CON CONTACTO METALICO", Descripcion = "TAMAÑO: 44.5 cm x 15 cm", Precio = 50.00m, ImagenURL = "teclado10.png" },
             new Producto { Nombre = "Mouse Philips Mini inalámbrico", Descripcion = "Diseño curvado para comodidad durante largas horas, con conectividad Bluetooth y batería recargable", Precio = 19.99m, ImagenURL = "mouse1.png" },
             new Producto { Nombre = "MOUSE GAMER RAZER INALAMBRICO", Descripcion = "Compacto, preciso y confiable, ideal para tareas cotidianas, con conexión cableada para evitar retrasos.", Precio = 35.50m, ImagenURL = "mouse2.png" },
             new Producto { Nombre = "MOUSE ALÁMBRICO ÓPTICO ARGOM CLASSIC", Descripcion = "Diseño vertical para reducir la tensión en la muñeca, ideal para usuarios con problemas de túnel carpiano.", Precio = 8.00m, ImagenURL = "mouse3.png" },
             new Producto { Nombre = "MOUSE Vector KMW-330BK Marca Klip Xtreme", Descripcion = "Sensores avanzados para un rastreo ultra preciso en superficies lisas o reflectantes, con botones silenciosos.", Precio = 15.00m, ImagenURL = "mouse4.png" },
             new Producto { Nombre = "MOUSE OPTICO INALAMBRICO USB BLACK PANTER", Descripcion = "Control preciso mediante una bola de desplazamiento fija, ideal para usuarios que buscan reducir el movimiento de la muñeca.", Precio = 10.00m, ImagenURL = "mouse5.png" },
             new Producto { Nombre = "MOUSE GAMING ADATA XPG SLINGSHOT", Descripcion = "Simétrico, apto para usuarios diestros y zurdos, con botones de clic suaves y una rueda de desplazamiento fluida.", Precio = 18.25m, ImagenURL = "mouse6.png" },
             new Producto { Nombre = "Redragon M801 Gaming Mouse", Descripcion = "Iluminación personalizable, alta sensibilidad (12,000 DPI) y botones programables para un rendimiento óptimo en juegos.", Precio = 24.99m, ImagenURL = "mouse7.png" },
             new Producto { Nombre = "MOUSE INALAMBRICO XTECHCapitan America", Descripcion = "Equipado con controles por gestos y batería recargable, perfecto para usuarios multitarea en Mac y Windows.", Precio = 10.00m, ImagenURL = "mouse8.png" },
             new Producto { Nombre = "Mouse Brigadier T-DAGGER", Descripcion = "Carcasa perforada para reducir peso, con sensibilidad ajustable (hasta 16,000 DPI) y botones optimizados para juegos competitivos.", Precio = 25.00m, ImagenURL = "mouse9.png" },
             new Producto { Nombre = "Logitech Wireless Mouse", Descripcion = "Pequeño y liviano, fácil de transportar, con tecnología inalámbrica de 2.4 GHz y batería de larga duración.", Precio = 15.99m, ImagenURL = "mouse10.png" },
        };

                // Insertar productos en la base de datos
                await _database.InsertAllAsync(products);
                Console.WriteLine($"Inserted {products.Count} products.");

            }
        }

        // Obtener todos los productos
        public Task<List<Producto>> ObtenerProductosAsync()
        {
            return _database.Table<Producto>().ToListAsync();
        }

        public Task<int> AgregarProductoAsync(Producto product)
        {
            return _database.InsertAsync(product);
        }

        public Task<int> ModificarProductoAsync(Producto product)
        {
            return _database.UpdateAsync(product);
        }

        public Task<int> EliminarProductoAsync(Producto product)
        {
            return _database.DeleteAsync(product);
        }

        //-----------------------------------COMPRA-----------------------------------------

        public Task<List<Compra>> GetComprasAsync()
        {
            return _database.Table<Compra>().ToListAsync();
        }

        public Task<int> SaveCompraAsync(Compra compra)
        {
            if (compra.Id != 0)
            {
                return _database.UpdateAsync(compra);
            }
            else
            {
                return _database.InsertAsync(compra);
            }
        }

        public Task<int> DeleteCompraAsync(Compra compra)
        {
            return _database.DeleteAsync(compra);
        }




        //-------------------------------CATEGORY------------------------------------------------------------------------

        //public async Task<List<Category>> GetResultado()
        //{
        //    return await _database.Table<Category>().ToListAsync();
        //}

        //public async Task<Category> GetById(int id)
        //{
        //    return await _database.Table<Category>().Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task Create(Category categoria)
        //{
        //    await _database.InsertAsync(categoria);
        //}
        //public async Task Update(Category categoria)
        //{
        //    await _database.UpdateAsync(categoria);
        //}
        //public async Task Delete(Category categoria)
        //{
        //    await _database.DeleteAsync(categoria);
        //}
    }
}
