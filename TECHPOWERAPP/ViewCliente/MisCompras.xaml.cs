using SQLite;
using System.Collections.ObjectModel;
using TECHPOWERAPP.Login;
using Newtonsoft.Json;


namespace TECHPOWERAPP.ViewCliente;

public partial class MisCompras : ContentPage
{
    private readonly DBService _dbService;

    private List<Producto> productos;
    private ObservableCollection<Producto> productosSeleccionados;
    private decimal totalCompra = 0;

    public MisCompras()
	{
		InitializeComponent();
        CargarProductos();
        ProductosPicker.ItemsSource = productos;
        productosSeleccionados = new ObservableCollection<Producto>();
        ProductosSeleccionadosListView.ItemsSource = productosSeleccionados;


        MetodoPagoPicker.SelectedIndexChanged += MetodoPagoPicker_SelectedIndexChanged;

        _dbService = App.DBService;
    }

    private void CargarProductos()
    {
        productos = new List<Producto>
        {
             new Producto { Nombre = "Monitor HP M24fwa FHP ",Precio = 239.00m, ImagenURL = "monitor1.png" },
             new Producto { Nombre = "Monitor Gamer Curvado ",Precio = 469.00m, ImagenURL = "monitor2.png" },
             new Producto { Nombre = "Monitor HP", Precio = 329.00m, ImagenURL = "monitor3.png" },
             new Producto { Nombre = "Monitor DELL FHD",Precio = 119.00m, ImagenURL = "monitor4.png" },
             new Producto { Nombre = "Monitor HP FHD",Precio = 180.90m, ImagenURL = "monitor5.png" },
             new Producto { Nombre = "Monitor Gamer Curvado ASUS",Precio = 449.00m, ImagenURL = "monitor6.png" },
             new Producto { Nombre = "Monitor Gamer Curvado HP FHD",Precio = 299.95m, ImagenURL = "monitor7.png" },
             new Producto { Nombre = "Monitor HP M24fw FHP",Precio = 179.00m, ImagenURL = "monitor8.png" },
             new Producto { Nombre = "Monitor Gamer Curvado Rojo",Precio = 189.00m, ImagenURL = "monitor9.png" },
             new Producto { Nombre = "Monitor Gamer Curvado HP",Precio = 579.86m, ImagenURL = "monitor10.png" },
             new Producto { Nombre = "TECLADO ERGONÓMICO",Precio = 45.00m, ImagenURL = "teclado1.png" },
             new Producto { Nombre = "TECLADO INHALÁMRICO",Precio = 30.00m, ImagenURL = "teclado2.png" },
             new Producto { Nombre = "TECLADO GAMER",Precio = 50.00m, ImagenURL = "teclado3.png" },
             new Producto { Nombre = "TECLADO MULTIMEDIA",Precio = 35.00m, ImagenURL = "teclado4.png" },
             new Producto { Nombre = "TECLADO MULTIMEDIA",Precio = 40.00m, ImagenURL = "teclado5.png" },
             new Producto { Nombre = "TECLADO NUMÉRICO",Precio = 10.00m, ImagenURL = "teclado6.png" },
             new Producto { Nombre = "TECLADO PLEGABLE",Precio = 25.00m, ImagenURL = "teclado7.png" },
             new Producto { Nombre = "TECLADO QWERTY",Precio = 20.00m, ImagenURL = "teclado8.png" },
             new Producto { Nombre = "TECLADO TÁCTIL",Precio = 40.00m, ImagenURL = "teclado9.png" },
             new Producto { Nombre = "TECLADO CON CONTACTO METALICO",Precio = 50.00m, ImagenURL = "teclado10.png" },
             new Producto { Nombre = "Mouse Philips Mini inalámbrico",Precio = 19.99m, ImagenURL = "mouse1.png" },
             new Producto { Nombre = "MOUSE GAMER RAZER INALAMBRICO",Precio = 35.50m, ImagenURL = "mouse2.png" },
             new Producto { Nombre = "MOUSE ALÁMBRICO ÓPTICO ARGOM CLASSIC",Precio = 8.00m, ImagenURL = "mouse3.png" },
             new Producto { Nombre = "MOUSE Vector KMW-330BK Marca Klip Xtreme",Precio = 15.00m, ImagenURL = "mouse4.png" },
             new Producto { Nombre = "MOUSE OPTICO INALAMBRICO USB BLACK PANTER",Precio = 10.00m, ImagenURL = "mouse5.png" },
             new Producto { Nombre = "MOUSE GAMING ADATA XPG SLINGSHOT",Precio = 18.25m, ImagenURL = "mouse6.png" },
             new Producto { Nombre = "Redragon M801 Gaming Mouse",Precio = 24.99m, ImagenURL = "mouse7.png" },
             new Producto { Nombre = "MOUSE INALAMBRICO XTECHCapitan America",Precio = 10.00m, ImagenURL = "mouse8.png" },
             new Producto { Nombre = "Mouse Brigadier T-DAGGER",Precio = 25.00m, ImagenURL = "mouse9.png" },
             new Producto { Nombre = "Logitech Wireless Mouse",Precio = 15.99m, ImagenURL = "mouse10.png" },
        // Agrega más productos aquí
    };
    }

    private void ProductosPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        var productoSeleccionado = picker.SelectedItem as Producto;

                if (productoSeleccionado != null)
        {
            var productoExistente = productosSeleccionados.FirstOrDefault(p => p.Nombre == productoSeleccionado.Nombre);
            if (productoExistente != null)
            {
                productoExistente.Cantidad++;
                totalCompra += productoSeleccionado.Precio;
            }
            else
            {
                productosSeleccionados.Add(new Producto
                {
                    Nombre = productoSeleccionado.Nombre,
                    ImagenURL = productoSeleccionado.ImagenURL,
                    Precio = productoSeleccionado.Precio,
                    Cantidad = 1
                });
                totalCompra += productoSeleccionado.Precio;
            }

            ProductosSeleccionadosListView.ItemsSource = null;
            ProductosSeleccionadosListView.ItemsSource = productosSeleccionados;
            TotalCompraEntry.Text = totalCompra.ToString("C");
        }
        //if (productoSeleccionado != null && !productosSeleccionados.Contains(productoSeleccionado))
        //{
        //    //ProductoSeleccionadoEntry.Text = productoSeleccionado.Nombre;
        //    //PrecioSeleccionadoEntry.Text = productoSeleccionado.Precio.ToString("C");
        //    productosSeleccionados.Add(productoSeleccionado);
        //    totalCompra += productoSeleccionado.Precio;
        //    TotalCompraEntry.Text = totalCompra.ToString("C");
        //}
    }

    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string ImagenURL { get; set; }

        public int Cantidad { get; set; } = 1; // Valor por defecto de 1


    }

    private void eliminar_Clicked(object sender, EventArgs e)
    {
        var productoSeleccionado = ProductosSeleccionadosListView.SelectedItem as Producto;
        if (productoSeleccionado != null)
        {
            if (productoSeleccionado.Cantidad > 1)
            {
                productoSeleccionado.Cantidad--;
                totalCompra -= productoSeleccionado.Precio;
            }
            else
            {
                productosSeleccionados.Remove(productoSeleccionado);
                totalCompra -= productoSeleccionado.Precio;
            }
            ProductosSeleccionadosListView.ItemsSource = null;
            ProductosSeleccionadosListView.ItemsSource = productosSeleccionados;
            TotalCompraEntry.Text = totalCompra.ToString("C");
        }
    }


    private void MetodoPagoPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (MetodoPagoPicker.SelectedItem.ToString() == "Tarjeta")
        {
            NumeroTarjetaEntry.IsVisible = true;
        }
        else
        {
            NumeroTarjetaEntry.IsVisible = false;
        }
    }

    private async void guardarCompra_Clicked(object sender, EventArgs e)
    {
        var nombreCompleto = NombreCompletoEntry.Text;
        var telefono = TelefonoEntry.Text;
        var direccion = DireccionEntry.Text;
        var metodoPago = MetodoPagoPicker.SelectedItem.ToString();
        var numeroTarjeta = NumeroTarjetaEntry.Text;
        var metodoEntrega = MetodoEntregaPicker.SelectedItem.ToString();


        var productosJson = JsonConvert.SerializeObject(productosSeleccionados);


        var compra = new Compra
        {
            NombreCompleto = nombreCompleto,
            Telefono = telefono,
            Direccion = direccion,
            MetodoPago = metodoPago,
            NumeroTarjeta = metodoPago == "Tarjeta" ? numeroTarjeta : null,
            MetodoEntrega = metodoEntrega,
            Productos = productosJson,
            Total = totalCompra
        };

        await App.DBService.SaveCompraAsync(compra);

        var mensaje = $"Compra Exitosa!\n\n" +
                      $"Cliente: {nombreCompleto}\n" +
                      $"Teléfono: {telefono}\n" +
                      $"Dirección: {direccion}\n" +
                      $"Método de Pago: {metodoPago}\n" +
                      (metodoPago == "Tarjeta" ? $"Número de Tarjeta: {numeroTarjeta}\n" : "") +
                      $"Método de Entrega: {metodoEntrega}\n\n" +
                      $"Productos:\n";

        foreach (var producto in productosSeleccionados)
        {
            mensaje += $"{producto.Nombre} - {producto.Cantidad} x {producto.Precio:C}\n";
        }

        mensaje += $"\nTotal: {totalCompra:C}";

        await DisplayAlert("Compra Exitosa", mensaje, "OK");
    }

    private async void volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MiPerfil());
    }
}

