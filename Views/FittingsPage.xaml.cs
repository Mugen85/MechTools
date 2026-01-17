using MechTools.ViewModels; // Assicurati che ci sia questo using

namespace MechTools.Views
{
    public partial class FittingsPage : ContentPage
    {
        public FittingsPage()
        {
            InitializeComponent();

            // COLLEGAMENTO MANUALE (Più robusto)
            // Qui creiamo il "cervello" e lo diamo alla pagina
            BindingContext = new FittingsViewModel();
        }
    }
}