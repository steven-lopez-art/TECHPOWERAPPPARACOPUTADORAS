using TECHPOWERAPP.ViewAdmin;
using TECHPOWERAPP.ViewCliente;


namespace TECHPOWERAPP.Login;

public partial class LoginPage : ContentPage
{
    private readonly DBService _databaseService;
    public LoginPage()
	{
		InitializeComponent();
        _databaseService = new DBService();
    }

    private async void Inicio_Clicked(object sender, EventArgs e)
    {
        var email = UsuarioEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Por favor, introduce todos los campos.", "OK");
            return;
        }

        var user = await _databaseService.GetUserByEmailAndPasswordAsync(email, password);

        if (user != null)
        {
            Preferences.Set("savedUser", email);
            Preferences.Set("savedPassword", password);

            if (email == "Admin" && password == "123")
            {
                await DisplayAlert("Éxito", "Inicio de sesión como administrador exitoso.", "OK");
                await Navigation.PushAsync(new AdminPage()); // Redirigir a la página de clientes

            }
            else
            {
                await DisplayAlert("Éxito", "Inicio de sesión como cliente exitoso.", "OK");
                await Navigation.PushAsync(new ClientePage()); // Redirigir a la página de clientes
            }
        }
        else
        {
            await DisplayAlert("Error", "Correo o contraseña incorrectos.", "OK");
        }
    }

    private async void Registrarse_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Registrarse());
    }
}