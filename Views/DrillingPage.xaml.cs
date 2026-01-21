using MechTools.ViewModels;

namespace MechTools.Views
{
    public partial class DrillingPage : ContentPage
    {
        public DrillingPage()
        {
            InitializeComponent();
            BindingContext = new DrillingViewModel();
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