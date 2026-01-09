using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MechTools.Services;

namespace MechTools.ViewModels
{
    // Ereditiamo da ObservableObject: ci dà i superpoteri per notificare la grafica
    public partial class BoltViewModel : ObservableObject
    {
        // PROPRIETÀ
        // [ObservableProperty] crea in automatico la proprietà pubblica "InputText"
        // e gestisce l'aggiornamento della grafica quando cambia.
        [ObservableProperty]
        private string? inputText;

        [ObservableProperty]
        private string? resultText;

        // COMANDI
        // [RelayCommand] trasforma questo metodo in un comando che possiamo collegare
        // al click di un bottone nell'interfaccia.
        [RelayCommand]
        void Calculate()
        {
            // 1. Pulizia: Se non ha scritto nulla, avvisiamo.
            if (string.IsNullOrWhiteSpace(InputText))
            {
                ResultText = "Inserisci una vite (es. M8) o una chiave (es. 13)";
                return;
            }

            string input = InputText.Trim(); // Rimuove spazi vuoti accidentali

            // 2. Proviamo a cercare come VITE (es. "M8")
            // Se l'utente scrive solo "8", noi aggiungiamo "M" per aiutarlo
            string searchAsBolt = input.StartsWith("M", StringComparison.CurrentCultureIgnoreCase) ? input : "M" + input;

            var boltInfo = BoltService.GetBoltInfo(searchAsBolt);

            if (boltInfo != null)
            {
                // Trovato come vite!
                ResultText = $"Vite {boltInfo.ThreadSize}:\n" +
                             $"🔧 Chiave Fissa: {boltInfo.HexWrenchSize} mm\n" +
                             $"🔩 Brugola: {boltInfo.AllenWrenchSize} mm";
                return;
            }

            // 3. Se non è una vite, proviamo a cercare come CHIAVE (es. "13")
            if (int.TryParse(input, out int wrenchSize))
            {
                var boltFromWrench = BoltService.GetBoltByHexWrench(wrenchSize);
                if (boltFromWrench != null)
                {
                    // Trovato come chiave!
                    ResultText = $"La chiave {wrenchSize} mm serve per:\n" +
                                 $"Vite Standard: {boltFromWrench.ThreadSize}";
                    return;
                }
            }

            // 4. Nessun risultato
            ResultText = "Nessuna corrispondenza trovata.";
        }

        [RelayCommand]
        void Clear()
        {
            InputText = string.Empty;
            ResultText = string.Empty;
        }
    }
}