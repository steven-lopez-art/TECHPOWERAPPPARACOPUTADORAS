using TECHPOWERAPP.Login;
using SQLite;


namespace TECHPOWERAPP.ViewAdmin;

public partial class InventarioProductos : ContentPage
{
    private readonly DBService _database;
    public InventarioProductos()
	{
		InitializeComponent();
        _database = new DBService();
        LoadProducts();
    }

    private async void LoadProducts()
    {
        var products = await _database.ObtenerProductosAsync();
        Console.WriteLine($"Loaded {products.Count} products.");
        ProductListView.ItemsSource = products;
    }

    private async void volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminPage());

    }
}