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
    }
}