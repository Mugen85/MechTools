using MechTools.ViewModels; // Assicurati che questo namespace sia corretto per il tuo progetto

namespace MechTools.Views;

public partial class ConvertersPage : ContentPage
{
    // Variabile "semaforo" per evitare loop infiniti tra i due convertitori
    private bool _isConverting = false;

    public ConvertersPage()
    {
        InitializeComponent();

        // Se usi un ViewModel per la parte dei pollici, assicurati che sia collegato qui.
        // Se lo colleghi via XAML o Dependency Injection, questa riga potrebbe non servire.
        // Ma di solito si trova qui:
         BindingContext = new ConvertersViewModel(); 
    }

    // --- LOGICA CONVERTITORE PRESSIONE (BAR <-> PSI) ---

    private void TxtBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isConverting) return; // Se stiamo già scrivendo nei PSI, fermati
        _isConverting = true;

        try
        {
            if (double.TryParse(TxtBar.Text, out double bar))
            {
                // Formula: 1 Bar = 14.5038 PSI
                double psi = bar * 14.50377;
                TxtPsi.Text = Math.Round(psi, 2).ToString();
            }
            else
            {
                // Se cancello tutto, pulisci anche l'altro campo
                if (string.IsNullOrEmpty(TxtBar.Text)) TxtPsi.Text = "";
            }
        }
        catch { }
        finally
        {
            _isConverting = false; // Riapri il semaforo
        }
    }

    private void TxtPsi_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isConverting) return; // Se stiamo già scrivendo nei BAR, fermati
        _isConverting = true;

        try
        {
            if (double.TryParse(TxtPsi.Text, out double psi))
            {
                // Formula: Bar = PSI / 14.5038
                double bar = psi / 14.50377;
                TxtBar.Text = Math.Round(bar, 2).ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(TxtPsi.Text)) TxtBar.Text = "";
            }
        }
        catch { }
        finally
        {
            _isConverting = false;
        }
    }
}