using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MechTools.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MechTools.ViewModels
{
    public partial class ConvertersViewModel : ObservableObject
    {
        // Input dell'utente (Stringa per accettare anche "/")
        [ObservableProperty]
        private string inputValue;

        // Risultato visualizzato
        [ObservableProperty]
        private string resultText;

        // Lista di riferimento rapido
        [ObservableProperty]
        private ObservableCollection<ConversionItem> quickList;

        public ConvertersViewModel()
        {
            ResultText = "Inserisci un valore (es. 1/2 o 0.5)";
            LoadQuickList();
        }

        [RelayCommand]
        void Convert()
        {
            if (string.IsNullOrWhiteSpace(InputValue))
            {
                ResultText = "Inserisci un numero.";
                return;
            }

            double inches = 0;
            string input = InputValue.Trim();

            try
            {
                // LOGICA SMART: Gestione frazioni (es. "3/8")
                if (input.Contains("/"))
                {
                    var parts = input.Split('/');
                    if (parts.Length == 2 &&
                        double.TryParse(parts[0], out double num) &&
                        double.TryParse(parts[1], out double den) && den != 0)
                    {
                        inches = num / den;
                    }
                    else
                    {
                        ResultText = "Frazione non valida.";
                        return;
                    }
                }
                else
                {
                    // Gestione numero decimale (gestisce sia punto che virgola)
                    input = input.Replace(",", ".");
                    if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out inches))
                    {
                        ResultText = "Numero non valido.";
                        return;
                    }
                }

                // Calcolo finale: 1 pollice = 25.4 mm
                double mm = inches * 25.4;
                ResultText = $"{inches:0.###}\"  =  {mm:0.00} mm";
            }
            catch
            {
                ResultText = "Errore di conversione.";
            }
        }

        // Popola la tabella di riferimento (i valori più usati in officina)
        void LoadQuickList()
        {
            QuickList = new ObservableCollection<ConversionItem>
            {
                // Fino a 1 pollice
                new ConversionItem { Fraction = "1/16", DecimalInch = 0.0625, Mm = 1.59 },
                new ConversionItem { Fraction = "1/8",  DecimalInch = 0.125,  Mm = 3.17 },
                new ConversionItem { Fraction = "3/16", DecimalInch = 0.1875, Mm = 4.76 },
                new ConversionItem { Fraction = "1/4",  DecimalInch = 0.250,  Mm = 6.35 },
                new ConversionItem { Fraction = "5/16", DecimalInch = 0.3125, Mm = 7.94 },
                new ConversionItem { Fraction = "3/8",  DecimalInch = 0.375,  Mm = 9.52 },
                new ConversionItem { Fraction = "7/16", DecimalInch = 0.4375, Mm = 11.11 },
                new ConversionItem { Fraction = "1/2",  DecimalInch = 0.500,  Mm = 12.70 },
                new ConversionItem { Fraction = "9/16", DecimalInch = 0.5625, Mm = 14.29 },
                new ConversionItem { Fraction = "5/8",  DecimalInch = 0.625,  Mm = 15.87 },
                new ConversionItem { Fraction = "3/4",  DecimalInch = 0.750,  Mm = 19.05 },
                new ConversionItem { Fraction = "7/8",  DecimalInch = 0.875,  Mm = 22.22 },
                new ConversionItem { Fraction = "1\"",  DecimalInch = 1.000,  Mm = 25.40 },

                // Oltre 1 pollice (misure comuni)
                new ConversionItem { Fraction = "1-1/8", DecimalInch = 1.125, Mm = 28.57 },
                new ConversionItem { Fraction = "1-1/4", DecimalInch = 1.250, Mm = 31.75 },
                new ConversionItem { Fraction = "1-3/8", DecimalInch = 1.375, Mm = 34.92 },
                new ConversionItem { Fraction = "1-1/2", DecimalInch = 1.500, Mm = 38.10 },
                new ConversionItem { Fraction = "1-5/8", DecimalInch = 1.625, Mm = 41.27 },
                new ConversionItem { Fraction = "1-3/4", DecimalInch = 1.750, Mm = 44.45 },
                new ConversionItem { Fraction = "1-7/8", DecimalInch = 1.875, Mm = 47.62 },
                new ConversionItem { Fraction = "2\"",   DecimalInch = 2.000, Mm = 50.80 },
            };
        }
    }
}