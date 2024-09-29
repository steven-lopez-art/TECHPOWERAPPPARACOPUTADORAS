namespace TECHPOWERAPP.Login;

public partial class Registrarse : ContentPage
{
    private readonly DBService _databaseService;
    public Registrarse()
	{
		InitializeComponent();
        _databaseService = new DBService();

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var email = emailEntry.Text;
        var password = passwordEntry.Text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Por favor, introduce todos los campos.", "OK");
            return;
        }

        var user = new User { Email = email, Password = password, IsAdmin = false };
        await _databaseService.RegisterUserAsync(user);

        await DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");
        await Navigation.PopAsync(); // Regresa a la página anterior (página de inicio de sesión)
    }
}