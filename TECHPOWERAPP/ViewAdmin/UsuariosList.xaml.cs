using TECHPOWERAPP.Login;

namespace TECHPOWERAPP.ViewAdmin;

public partial class UsuariosList : ContentPage
{
    private readonly DBService _databaseService;
    public UsuariosList()
	{
		InitializeComponent();
        _databaseService = new DBService();
        LoadUsers();
    }

    private async void LoadUsers()
    {
        List<User> users = await _databaseService.GetAllUserAsync();
        usersCollectionView.ItemsSource = users;
    }

    private async void Usuario_Clicked(object sender, EventArgs e)
    {
        // Obtener el usuario a eliminar del CommandParameter
        var button = sender as Button;
        var user = button?.CommandParameter as User;

        if (user != null)
        {
            // Confirmar eliminación
            bool confirm = await DisplayAlert("Confirmar", $"¿Estás seguro de eliminar a {user.Email}?", "Sí", "No");
            if (confirm)
            {
                await _databaseService.DeleteUserAsync(user); // Eliminar de la base de datos
                LoadUsers(); // Recargar la lista de usuarios
            }
        }
    }

    private async void volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminPage());

    }
}