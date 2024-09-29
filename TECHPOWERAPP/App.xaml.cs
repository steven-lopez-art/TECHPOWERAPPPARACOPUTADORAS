using TECHPOWERAPP.Login;

namespace TECHPOWERAPP
{
    public partial class App : Application
    {

        public static DBService DBService { get; private set; }

        public App()
        {
            InitializeComponent();

            DBService = new DBService();    

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
