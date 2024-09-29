using TECHPOWERAPP.Login;

namespace TECHPOWERAPP.ViewAdmin;

public partial class Categorias : ContentPage
{
    private List<string> productos;

    public Categorias()
	{
         InitializeComponent();
        productos = new List<string>();
        CargarProductosDesdePreferencias();  // Cargar los productos guardados
        MostrarProductos();  // Mostrar los productos al iniciar

    }

    private void CargarProductosDesdePreferencias()
    {
        string productosSerializados = Preferences.Get("productos", string.Empty);  // Obtener los productos de Preferences
        if (!string.IsNullOrEmpty(productosSerializados))
        {
            productos = productosSerializados.Split(',').ToList();  // Deserializar la cadena en una lista de productos
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
         string nombre = NombreEntry.Text;  // Obtener el nombre ingresado

    if (!string.IsNullOrEmpty(nombre))
    {
        productos.Add(nombre);  // Agregar el producto a la lista
        GuardarProductosEnPreferencias();  // Guardar los productos en Preferences
        MostrarProductos();  // Mostrar la lista actualizada

        NombreEntry.Text = string.Empty;  // Limpiar la entrada de texto
    }
    else
    {
        DisplayAlert("Error", "Ingrese un nombre de producto", "OK");
    }

    }


    private void GuardarProductosEnPreferencias()
    {
        string productosSerializados = string.Join(",", productos);  // Serializar la lista de productos a una cadena
        Preferences.Set("productos", productosSerializados);  // Guardar la cadena en Preferences
    }






    // Método para mostrar los productos en la lista
    private void MostrarProductos()
    {
        ProductosStack.Children.Clear();  // Limpiar la lista visual

        // Mostrar cada producto
        foreach (var producto in productos)
        {
            var productoLayout = new HorizontalStackLayout
            {
                Spacing = 10,
                Margin = new Thickness(0, 5, 0, 5)
            };

            // Etiqueta para el nombre del producto
            var nombreLabel = new Label
            {
                Text = producto,
                VerticalOptions = LayoutOptions.Center
            };

            // Botón para modificar el producto
            var modificarButton = new Button
            {
                Text = "Modificar",
                FontFamily = "Family Vacation",
                FontSize = 22,
                WidthRequest = 100,
                HeightRequest = 40,
                BackgroundColor = Colors.AntiqueWhite
            };
            modificarButton.Clicked += (s, e) => OnModificarClicked(producto);

            // Botón para eliminar el producto
            var eliminarButton = new Button
            {
                Text = "Eliminar",
                FontFamily = "Family Vacation",
                FontSize = 22,
                WidthRequest = 100,
                HeightRequest = 40,
                BackgroundColor = Colors.AntiqueWhite
            };
            eliminarButton.Clicked += (s, e) => OnEliminarClicked(producto);

            // Añadir elementos al layout
            productoLayout.Children.Add(nombreLabel);
            productoLayout.Children.Add(modificarButton);
            productoLayout.Children.Add(eliminarButton);

            // Añadir el layout del producto a la vista principal
            ProductosStack.Children.Add(productoLayout);
        }

    }

    // Método para modificar un producto
    private void OnModificarClicked(string producto)
    {
        NombreEntry.Text = producto;  // Colocar el nombre del producto en la entrada
        productos.Remove(producto);   // Eliminar temporalmente el producto de la lista
    }

    // Método para eliminar un producto
    private void OnEliminarClicked(string producto)
    {
        productos.Remove(producto);  // Eliminar el producto de la lista
        GuardarProductosEnPreferencias();  // Guardar la lista actualizada en Preferences
        MostrarProductos();  // Mostrar la lista actualizada
    }

    private async void volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminPage());
    }
}

// Clase Producto
//public class Producto
//{
//    public string Nombre { get; set; }
//    public string Descripcion { get; set; }
//    public decimal Precio { get; set; }
//    public string ImagenUrl { get; set; }
//}

