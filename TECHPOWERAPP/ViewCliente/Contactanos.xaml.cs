namespace TECHPOWERAPP.ViewCliente;

public partial class Contactanos : ContentPage
{
	public Contactanos()
	{
		InitializeComponent();
	}

    private async void enviar_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Mensaje Enviado", "Gracias por contactarnos, TechPower te responderá pronto.", "OK");
    }

    private async void volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientePage());
    }
}