using MechTools.ViewModels;
namespace MechTools.Views // <--- 1. Namespace corretto
{
    public partial class KeysPage : ContentPage
    {
        // 2. Il costruttore DEVE chiamarsi come la classe
        public KeysPage()
        {
            InitializeComponent();

            // Se usavi il BindingContext qui, assicurati che ci sia:
            BindingContext = new BoltViewModel();
        }
        // QUANDO ENTRI NELLA PAGINA
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Blocca lo spegnimento schermo
            DeviceDisplay.Current.KeepScreenOn = true;
        }

        // QUANDO ESCI DALLA PAGINA
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Permetti allo schermo di spegnersi (per risparmiare batteria)
            DeviceDisplay.Current.KeepScreenOn = false;
        }
    }
}