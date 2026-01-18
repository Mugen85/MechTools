using CommunityToolkit.Mvvm.ComponentModel;
using MechTools.Models;
using MechTools.Services;
using System.Collections.ObjectModel;

namespace MechTools.ViewModels
{
    public partial class TorqueViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TorqueRow> torqueList;

        public TorqueViewModel()
        {
            var data = TorqueService.GetData();
            TorqueList = new ObservableCollection<TorqueRow>(data);
        }
    }
}