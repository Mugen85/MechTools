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
            // Pulizia base
            if (string.IsNullOrWhiteSpace(InputText))
            {
                ResultText = "Scrivi un numero (es. 13) o una vite (es. M8)";
                return;
            }

            string input = InputText.Trim().ToUpper(); // Rimuove spazi e mette maiuscolo

            // --- LOGICA AGGIORNATA ---

            // 1. PRIMA controlliamo se è un NUMERO PURO (Cerca Chiave)
            // Se scrivi "13", il programma capisce che cerchi la chiave, non la vite M13.
            if (int.TryParse(input, out int wrenchSize))
            {
                var boltFromWrench = BoltService.GetBoltByHexWrench(wrenchSize);

                if (boltFromWrench != null)
                {
                    ResultText = $"La chiave {wrenchSize} mm serve per:\n" +
                                 $"✅ Vite Standard: {boltFromWrench.ThreadSize} (Passo {boltFromWrench.Pitch})";
                    return; // Trovato! Usciamo.
                }
            }

            // 2. POI controlliamo se è una VITE
            // Se siamo arrivati qui, o non è un numero, oppure è un numero che non corrisponde a nessuna chiave.
            // Aggiungiamo "M" se l'utente se l'è dimenticata.
            string searchAsBolt = input.StartsWith("M") ? input : "M" + input;

            var boltInfo = BoltService.GetBoltInfo(searchAsBolt);

            if (boltInfo != null)
            {
                string result = $"Vite {boltInfo.ThreadSize} (Passo {boltInfo.Pitch}):\n" +
                                $"🔧 Chiave Fissa: {boltInfo.HexWrenchSize} mm";

                if (boltInfo.AllenWrenchSize > 0)
                {
                    result += $"\n🔩 Brugola: {boltInfo.AllenWrenchSize} mm";
                }

                ResultText = result;
                return;
            }

            // 3. Nessun risultato
            ResultText = "Nessuna corrispondenza trovata.\nProva 'M8' o '13'";
        }

        [RelayCommand]
        void Clear()
        {
            InputText = string.Empty;
            ResultText = string.Empty;
        }
    }
}