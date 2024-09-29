using TECHPOWERAPP.ViewModel;
using TECHPOWERAPP.ViewCliente;

namespace TECHPOWERAPP.ViewAdmin;

public partial class Teclado : ContentPage
{
    public Teclado()
	{
        InitializeComponent();
    }



    private async void venta2_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }

    private async void venta_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }


    private async void venta3_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }

    private async void venta4_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }

    private async void venta5_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }

    private async void venta6_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }


    private async void venta7_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }

    private async void venta8_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }

    private async void venta9_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }

    private async void venta10_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MisCompras());

    }

    private async void volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaCategoria());

    }
}