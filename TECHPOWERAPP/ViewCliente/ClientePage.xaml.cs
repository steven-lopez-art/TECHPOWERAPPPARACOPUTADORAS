using TECHPOWERAPP.Login;
using TECHPOWERAPP.ViewCliente;

namespace TECHPOWERAPP.ViewCliente;

public partial class ClientePage : ContentPage
{
	public ClientePage()
	{
		InitializeComponent();
	}

    private  void MenuButton_Clicked(object sender, EventArgs e)
    {
        MenuPanel1.IsVisible = !MenuPanel1.IsVisible; // Alternar la visibilidad del men�
    }

    private async void Categorias_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el men� antes de navegar
            MenuPanel1.IsVisible = false;

            // Navegar a la p�gina correspondiente
            ContentPage page = pageName switch
            {
                "ListaCategorias" => new ListaCategoria(),
                "MiPerfil" => new MiPerfil(),
                "MisCompras" => new MisCompras(),
                "Contactanos" => new Contactanos(),
                "LoginPage" => new LoginPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva p�gina utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }

    private async void Compras_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el men� antes de navegar
            MenuPanel1.IsVisible = false;

            // Navegar a la p�gina correspondiente
            ContentPage page = pageName switch
            {
                "ListaCategorias" => new ListaCategoria(),
                "MiPerfil" => new MiPerfil(),
                "MisCompras" => new MisCompras(),
                "Contactanos" => new Contactanos(),
                "LoginPage" => new LoginPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva p�gina utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }

    private async void contactos_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el men� antes de navegar
            MenuPanel1.IsVisible = false;

            // Navegar a la p�gina correspondiente
            ContentPage page = pageName switch
            {
                "ListaCategorias" => new ListaCategoria(),
                "MiPerfil" => new MiPerfil(),
                "MisCompras" => new MisCompras(),
                "Contactanos" => new Contactanos(),
                "LoginPage" => new LoginPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva p�gina utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }

    private async void cierre_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el men� antes de navegar
            MenuPanel1.IsVisible = false;

            // Navegar a la p�gina correspondiente
            ContentPage page = pageName switch
            {
                "ListaCategorias" => new ListaCategoria(),
                "MiPerfil" => new MiPerfil(),
                "MisCompras" => new MisCompras(),
                "Contactanos" => new Contactanos(),
                "LoginPage" => new LoginPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva p�gina utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }

    private async void Perfil_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Cerrar el men� antes de navegar
            MenuPanel1.IsVisible = false;

            // Navegar a la p�gina correspondiente
            ContentPage page = pageName switch
            {
                "ListaCategorias" => new ListaCategoria(),
                "MiPerfil" => new MiPerfil(),
                "MisCompras" => new MisCompras(),
                "Contactanos" => new Contactanos(),
                "LoginPage" => new LoginPage(),
                _ => null
            };

            if (page != null)
            {
                // Navegar a la nueva p�gina utilizando PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }
}