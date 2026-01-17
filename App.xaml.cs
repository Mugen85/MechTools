namespace MechTools
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // 1. FORZA IL TEMA SCURO (Così i testi bianchi rimangono bianchi)
            //UserAppTheme = AppTheme.Dark;

            // 2. Avvia la Shell
            MainPage = new AppShell();
        }
    }
}