using TECHPOWERAPP.Login;
using TECHPOWERAPP.ViewCliente;

namespace TECHPOWERAPP.ViewAdmin;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
	}

    private void MenuButton_Clicked(object sender, EventArgs e)
    {
        MenuPanel.IsVisible = !MenuPanel.IsVisible; // Alternar la visibilidad del menú
    }

    private  void Lcategoria_Clicked(object sender, EventArgs e)
    {
        
    }

    private async void ProStock_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el menú antes de navegar
            MenuPanel.IsVisible = false;

            // Navegar a la página correspondiente
            ContentPage page = pageName switch
            {
                "Categorias" => new Categorias(),
                "InventarioProductos" => new InventarioProductos(),
                "UsuariosList" => new UsuariosList(),
                "PageAdminis" => new AdminPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva página utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }


    private async void usuarios_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el menú antes de navegar
            MenuPanel.IsVisible = false;

            // Navegar a la página correspondiente
            ContentPage page = pageName switch
            {
                "Categorias" => new Categorias(),
                "InventarioProductos" => new InventarioProductos(),
                "UsuariosList" => new UsuariosList(),
                "PageAdminis" => new AdminPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva página utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }

    private async  void cierre_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el menú antes de navegar
            MenuPanel.IsVisible = false;

            // Navegar a la página correspondiente
            ContentPage page = pageName switch
            {
                "Categorias" => new Categorias(),
                "InventarioProductos" => new InventarioProductos(),
                "UsuariosList" => new UsuariosList(),
                "LoginPage" => new LoginPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva página utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }

    private async void categoria_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el menú antes de navegar
            MenuPanel.IsVisible = false;

            // Navegar a la página correspondiente
            ContentPage page = pageName switch
            {
                "Categorias" => new Categorias(),
                "InventarioProductos" => new InventarioProductos(),
                "UsuariosList" => new UsuariosList(),
                "PageAdminis" => new AdminPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva página utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }
}