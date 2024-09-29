
using TECHPOWERAPP.ViewAdmin;

namespace TECHPOWERAPP.ViewCliente;

public partial class ListaCategoria : ContentPage
{
	public ListaCategoria()
	{
		InitializeComponent();
	}

    private async void Teclado_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Teclado());
    }

    private async void Monitor_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Monitor());
    }

    private async void Mouse_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Mouse());
    }

    private async void volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientePage());
    }
}