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


        private async void BtnKeys_Clicked(object sender, EventArgs e)
        {
            // VIBRAZIONE (Feedback tattile)
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            }
            catch { /* Ignora se non c'è il motorino vibrazione */ }

            await Shell.Current.GoToAsync(nameof(KeysPage));
        }

        private async void BtnFittings_Clicked(object sender, EventArgs e)
        {
            // VIBRAZIONE (Feedback tattile)
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            }
            catch { /* Ignora se non c'è il motorino vibrazione */ }

            await Shell.Current.GoToAsync(nameof(KeysPage));
        }

        private async void BtnDrilling_Clicked(object sender, EventArgs e)
        {
            // VIBRAZIONE (Feedback tattile)
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            }
            catch { /* Ignora se non c'è il motorino vibrazione */ }

            await Shell.Current.GoToAsync(nameof(DrillingPage));
        }
        

        private async void BtnTorque_Clicked(object sender, EventArgs e)
        {
            // VIBRAZIONE (Feedback tattile)
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            }
            catch { /* Ignora se non c'è il motorino vibrazione */ }

            await Shell.Current.GoToAsync(nameof(TorquePage));
        }
        

        private async void BtnRpm_Clicked(object sender, EventArgs e)
        {
            // VIBRAZIONE (Feedback tattile)
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            }
            catch { /* Ignora se non c'è il motorino vibrazione */ }

            await Shell.Current.GoToAsync(nameof(RpmPage));
        }
        

        private async void BtnConverter_Clicked(object sender, EventArgs e)
        {
            // VIBRAZIONE (Feedback tattile)
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            }
            catch { /* Ignora se non c'è il motorino vibrazione */ }

            await Shell.Current.GoToAsync(nameof(ConvertersPage));
        }

        // Torcia
        private async void BtnFlashlight_Clicked(object sender, EventArgs e)
        {
            // 1. Vibrazione (Feedback tattile)
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            }
            catch { /* Niente vibrazione */ }

            // 2. Logica Torcia
            try
            {
                // Per ora la ACCENDIAMO e basta. 
                // (Per spegnerla dovremmo gestire lo stato, ma iniziamo semplice)
                await Flashlight.Default.TurnOnAsync();
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Attenzione", "Il tuo dispositivo non ha il flash.", "OK");
            }
            catch (Exception)
            {
                // Se è già accesa o c'è un altro problema, proviamo a spegnerla (effetto Toggle manuale)
                try { await Flashlight.Default.TurnOffAsync(); } catch { }
            }
        }
    }
}