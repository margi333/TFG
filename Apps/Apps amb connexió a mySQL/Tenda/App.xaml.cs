

namespace Tenda
{
        public partial class App : Application
        {
        public bool IsLoggedIn { get; set; } = false;

        public Informacio Info { get; set; } = new Informacio();
        public App()
            {
                InitializeComponent();
            }

            protected override Window CreateWindow(IActivationState? activationState)
            {
                bool isLoggedIn = Preferences.Get("IsLoggedIn", false);
                if (isLoggedIn)
                {
                    return new Window(new AppShell());
                }
                else
                {
                    return new Window(new MainPage());
                }
            }
        }
}