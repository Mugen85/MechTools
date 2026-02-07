using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MechTools.Models;
using MechTools.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MechTools.ViewModels
{
    public partial class FittingsViewModel : ObservableObject
    {
        // 1. LA LISTA DATI
        // ObservableCollection aggiorna automaticamente l'interfaccia quando cambia il contenuto
        [ObservableProperty]
        private ObservableCollection<Fitting> fittingsList;

        // 2. TITOLO DINAMICO (Per sapere cosa stiamo guardando)
        [ObservableProperty]
        private string currentStandardName;

        // 3. VARIABILI INPUT CALIBRO (Stringhe per gestire meglio l'input vuoto o con virgola)
        [ObservableProperty]
        private string diameterTip;    // Misura punta

        [ObservableProperty]
        private string diameterBottom; // Misura fondo

        // 4. RISULTATO ANALISI
        [ObservableProperty]
        private string detectorResult;

        // --- COLORE DINAMICO (Per UI) ---
        [ObservableProperty]
        private Color standardColor; // Questo genera automaticamente "StandardColor" pubblico

        // --- GESTIONE VISIBILITÀ (MODALITÀ OFFICINA) ---

        [ObservableProperty]
        private bool isCalculatorMode = true; // Parte con i calcolatori visibili

        [ObservableProperty]
        private bool isTableMode = false;     // Tabelle nascoste all'inizio

        [ObservableProperty]
        private Color calcBtnColor = Colors.Orange; // Colore tasto attivo

        [ObservableProperty]
        private Color tableBtnColor = Colors.Transparent; // Colore tasto inattivo

        // --- COMANDI PER LO SWITCH ---

        [RelayCommand]
        void ShowCalculators()
        {
            IsCalculatorMode = true;
            IsTableMode = false;

            // Feedback visivo sui bottoni
            CalcBtnColor = Colors.Orange;
            TableBtnColor = Colors.Transparent;
        }

        [RelayCommand]
        void ShowTables()
        {
            IsCalculatorMode = false;
            IsTableMode = true;

            // Feedback visivo sui bottoni
            CalcBtnColor = Colors.Transparent;
            TableBtnColor = Colors.Orange;
        }

        public FittingsViewModel()
        {
            // Inizializziamo la lista vuota
            FittingsList = [];

            // Appena apriamo la pagina, carichiamo i GAS per default
            LoadGas();
        }

        // --- COMANDI (Bottoni) ---

        [RelayCommand]
        void LoadGas()
        {
            // Chiede al Service solo i raccordi GAS
            var data = FittingService.GetFittingsByType(FittingStandard.GasBSP);

            // Aggiorna la lista visibile
            FittingsList = new ObservableCollection<Fitting>(data);

            CurrentStandardName = "Standard: GAS BSP (Europa - Cilindrico)";
            StandardColor = Color.Parse("#007ACC"); // Blu
        }

        [RelayCommand]
        void LoadNpt()
        {
            // Chiede al Service solo i raccordi NPT
            var data = FittingService.GetFittingsByType(FittingStandard.NPT);

            // Aggiorna la lista visibile
            FittingsList = new ObservableCollection<Fitting>(data);

            CurrentStandardName = "Standard: NPT (USA - Conico)";
            StandardColor = Color.Parse("#D32F2F"); // Rosso
        }

        [RelayCommand]
        void LoadJic()
        {
            // Chiama il Service (Ora funziona perché JIC è nel Service!)
            var data = FittingService.GetFittingsByType(FittingStandard.JIC);
            FittingsList = new ObservableCollection<Fitting>(data);

            CurrentStandardName = "Standard: JIC 37° (SAE J514) - USA Oleodinamica";
            StandardColor = Color.Parse("#9C27B0"); // Viola
        }

        [RelayCommand]
        void Analyze()
        {
            // Pulizia input: gestiamo sia il punto che la virgola (es. "20.5" o "20,5")
            // Se l'utente lascia vuoto, consideriamo "0"
            string dTipClean = DiameterTip?.Replace(",", ".") ?? "0";
            string dBotClean = DiameterBottom?.Replace(",", ".") ?? "0";

            // Tentiamo di convertire il testo in numeri decimali (double)
            // CultureInfo.InvariantCulture serve per assicurarsi che il "." venga letto come separatore decimale
            bool isTipValid = double.TryParse(dTipClean, NumberStyles.Any, CultureInfo.InvariantCulture, out double dTip);
            bool isBotValid = double.TryParse(dBotClean, NumberStyles.Any, CultureInfo.InvariantCulture, out double dBot);

            if (isTipValid && isBotValid && dTip > 0 && dBot > 0)
            {
                // Se i numeri sono validi, chiamiamo il tuo Service
                string resultType = FittingService.AnalyzeThread(dTip, dBot);

                // Mostriamo il risultato
                DetectorResult = $"Risultato: {resultType}";
            }
            else
            {
                // Messaggio di errore se ha scritto lettere o lasciato vuoto
                DetectorResult = "Inserisci due misure valide (es. 20.9)";
            }
        }
    }
}