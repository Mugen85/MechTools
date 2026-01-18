namespace MechTools.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        // NOTA: Abbiamo tolto le "//" davanti ai nomi.
        // Questo attiva la navigazione con CRONOLOGIA (e quindi la freccia indietro).

        private async void BtnKeys_Clicked(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(KeysPage));

        private async void BtnFittings_Clicked(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(FittingsPage));

        private async void BtnDrilling_Clicked(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(DrillingPage));

        private async void BtnTorque_Clicked(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(TorquePage));

        private async void BtnRpm_Clicked(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(RpmPage));

        private async void BtnConverter_Clicked(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(ConvertersPage));
    }
}