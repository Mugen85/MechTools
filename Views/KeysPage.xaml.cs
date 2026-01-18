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
    }
}