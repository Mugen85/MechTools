using MechTools.ViewModels;

namespace MechTools.Views
{
    public partial class RpmPage : ContentPage
    {
        public RpmPage()
        {
            InitializeComponent();
            BindingContext = new RpmViewModel();
        }
    }
}