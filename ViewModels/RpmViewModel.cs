using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MechTools.Models;
using MechTools.Services;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MechTools.ViewModels
{
    public partial class RpmViewModel : ObservableObject
    {
        // DATI
        [ObservableProperty]
        private ObservableCollection<CuttingMaterial> materials;

        [ObservableProperty]
        private CuttingMaterial selectedMaterial;

        // INPUT UTENTE (Stringa per gestire virgole/punti)
        [ObservableProperty]
        private string diameterInput;

        // RISULTATI
        [ObservableProperty]
        private string rpmResult; // Es: "1250"

        [ObservableProperty]
        private string formulaDetails; // Es: "Vc: 30 | Ø: 10"

        public RpmViewModel()
        {
            // Carichiamo i dati dal servizio
            var data = MachiningService.GetMaterials();
            Materials = new ObservableCollection<CuttingMaterial>(data);

            // Selezioniamo l'acciaio dolce come default (è il più comune)
            SelectedMaterial = Materials.FirstOrDefault(m => m.Vc == 30) ?? Materials.First();

            RpmResult = "---";
            FormulaDetails = "Inserisci diametro e calcola";
        }

        [RelayCommand]
        void Calculate()
        {
            if (string.IsNullOrWhiteSpace(DiameterInput) || SelectedMaterial == null)
                return;

            // Pulizia input (sostituisce virgola con punto)
            string cleanInput = DiameterInput.Replace(",", ".");

            if (double.TryParse(cleanInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double diameter) && diameter > 0)
            {
                // FORMULA: (Vc * 1000) / (3.14 * Diametro)
                double rawRpm = (SelectedMaterial.Vc * 1000) / (Math.PI * diameter);

                // Arrotondiamo all'intero (i trapani non hanno decimali)
                int rpm = (int)Math.Round(rawRpm);

                RpmResult = $"{rpm}";
                FormulaDetails = $"Materiale: {SelectedMaterial.Name} (Vc {SelectedMaterial.Vc})\nUtensile: Ø {diameter} mm";
            }
            else
            {
                RpmResult = "ERR";
                FormulaDetails = "Diametro non valido";
            }
        }
    }
}