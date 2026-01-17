using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MechTools.Models;
using MechTools.Services;
using System.Collections.ObjectModel;

namespace MechTools.ViewModels
{
    public partial class DrillingViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ThreadItem> threadList;

        [ObservableProperty]
        private string currentFilterName;

        public DrillingViewModel()
        {
            // Carica standard all'avvio
            LoadStandard();
        }

        [RelayCommand]
        void LoadStandard()
        {
            var data = DrillingService.GetStandard();
            ThreadList = new ObservableCollection<ThreadItem>(data);
            CurrentFilterName = "Metrico Standard (Passo Grosso)";
        }

        [RelayCommand]
        void LoadFine()
        {
            var data = DrillingService.GetFine();
            ThreadList = new ObservableCollection<ThreadItem>(data);
            CurrentFilterName = "Metrico Passo Fine";
        }
    }
}