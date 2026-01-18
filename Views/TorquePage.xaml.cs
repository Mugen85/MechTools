using MechTools.ViewModels;

namespace MechTools.Views
{
    public partial class TorquePage : ContentPage
    {
        public TorquePage()
        {
            InitializeComponent();
            BindingContext = new TorqueViewModel();
        }
    }
}