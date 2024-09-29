using TECHPOWERAPP.Login;
using Newtonsoft.Json;

namespace TECHPOWERAPP.ViewCliente;

public partial class MiPerfil : ContentPage
{
    private readonly DBService _dbService;

    public MiPerfil()
	{
		InitializeComponent();
        LoadUserData();
        CargarCompras();

        _dbService = App.DBService;

    }

    private void LoadUserData()
    {
        // Recuperar el usuario y la contraseña de las preferencias
        string savedUser = Preferences.Get("savedUser", "No guardado");
        string savedPassword = Preferences.Get("savedPassword", "No guardado");

        UserNameLabel.Text = savedUser;
        PasswordLabel.Text = savedPassword;
    }

    private async void cerrarperfil_Clicked(object sender, EventArgs e)
    {
        // Lógica para cerrar sesión
        await DisplayAlert("Cerrar sesión", "Has cerrado sesión correctamente.", "OK");
        // Navegar a la página de inicio de sesión
        await Navigation.PopToRootAsync();
    }



    private async void CargarCompras()
    {
        ComprasListView.ItemsSource = await App.DBService.GetComprasAsync();
    }



    private async void ComprasListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var compraSeleccionada = e.SelectedItem as Compra;
        if (compraSeleccionada != null)
        {
            var productos = JsonConvert.DeserializeObject<List<Producto>>(compraSeleccionada.Productos);
            var mensaje = $"Cliente: {compraSeleccionada.NombreCompleto}\n" +
                          $"Teléfono: {compraSeleccionada.Telefono}\n" +
                          $"Dirección: {compraSeleccionada.Direccion}\n" +
                          $"Método de Pago: {compraSeleccionada.MetodoPago}\n" +
                          (compraSeleccionada.MetodoPago == "Tarjeta" ? $"Número de Tarjeta: {compraSeleccionada.NumeroTarjeta}\n" : "") +
                          $"Método de Entrega: {compraSeleccionada.MetodoEntrega}\n\n" +
                          $"Productos:\n";

            foreach (var producto in productos)
            {
                mensaje += $"{producto.Nombre} - {producto.Cantidad} x {producto.Precio:C}\n";
            }

            mensaje += $"\nTotal: {compraSeleccionada.Total:C}";

            await DisplayAlert("Detalles de la Compra", mensaje, "OK");
        }
    }

    private async void Modificar_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var compra = menuItem.CommandParameter as Compra;

        string nuevoTitulo = await DisplayPromptAsync("Modificar Título", "Ingrese el nuevo título de la compra:", initialValue: compra.NombreCompleto);
        if (!string.IsNullOrEmpty(nuevoTitulo))
        {
            compra.NombreCompleto = nuevoTitulo;
            await App.DBService.SaveCompraAsync(compra);
            CargarCompras();
        }
    }

    private async void Eliminar_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var compra = menuItem.CommandParameter as Compra;

        bool confirm = await DisplayAlert("Eliminar Compra", "¿Está seguro de que desea eliminar esta compra?", "Sí", "No");
        if (confirm)
        {
            await App.DBService.DeleteCompraAsync(compra);
            CargarCompras();
        }
    }

    private async void Ir_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());
    }

    private async void volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientePage());
    }
}