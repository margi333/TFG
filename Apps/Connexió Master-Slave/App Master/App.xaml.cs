using Microsoft.VisualBasic;

namespace App_Master
{
    public partial class App : Application
    {
        public socket Obj { get; set; } = new socket();
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage());
        }
    }
}