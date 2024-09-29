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
        // Recuperar el usuario y la contrase�a de las preferencias
        string savedUser = Preferences.Get("savedUser", "No guardado");
        string savedPassword = Preferences.Get("savedPassword", "No guardado");

        UserNameLabel.Text = savedUser;
        PasswordLabel.Text = savedPassword;
    }

    private async void cerrarperfil_Clicked(object sender, EventArgs e)
    {
        // L�gica para cerrar sesi�n
        await DisplayAlert("Cerrar sesi�n", "Has cerrado sesi�n correctamente.", "OK");
        // Navegar a la p�gina de inicio de sesi�n
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
                          $"Tel�fono: {compraSeleccionada.Telefono}\n" +
                          $"Direcci�n: {compraSeleccionada.Direccion}\n" +
                          $"M�todo de Pago: {compraSeleccionada.MetodoPago}\n" +
                          (compraSeleccionada.MetodoPago == "Tarjeta" ? $"N�mero de Tarjeta: {compraSeleccionada.NumeroTarjeta}\n" : "") +
                          $"M�todo de Entrega: {compraSeleccionada.MetodoEntrega}\n\n" +
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

        string nuevoTitulo = await DisplayPromptAsync("Modificar T�tulo", "Ingrese el nuevo t�tulo de la compra:", initialValue: compra.NombreCompleto);
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

        bool confirm = await DisplayAlert("Eliminar Compra", "�Est� seguro de que desea eliminar esta compra?", "S�", "No");
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