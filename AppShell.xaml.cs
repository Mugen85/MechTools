using MechTools.Views; // Assicurati ci sia questo using

namespace MechTools
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // REGISTRAZIONE ROTTE
            // Questo permette di navigare mantenendo la freccia "Indietro"
            Routing.RegisterRoute(nameof(KeysPage), typeof(KeysPage));
            Routing.RegisterRoute(nameof(FittingsPage), typeof(FittingsPage));
            Routing.RegisterRoute(nameof(DrillingPage), typeof(DrillingPage));
            Routing.RegisterRoute(nameof(TorquePage), typeof(TorquePage));
            Routing.RegisterRoute(nameof(RpmPage), typeof(RpmPage));
            Routing.RegisterRoute(nameof(ConvertersPage), typeof(ConvertersPage));
        }
    }
}