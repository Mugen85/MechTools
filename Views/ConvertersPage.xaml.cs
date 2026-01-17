using MechTools.ViewModels;

namespace MechTools.Views
{
    public partial class ConvertersPage : ContentPage
    {
        public ConvertersPage()
        {
            InitializeComponent();
            BindingContext = new ConvertersViewModel();
        }
    }
}