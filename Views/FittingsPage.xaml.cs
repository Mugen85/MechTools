using MechTools.ViewModels;
namespace MechTools.Views;

public partial class FittingsPage : ContentPage
{
    public FittingsPage()
    {
        InitializeComponent();
        // Assicurati che il BindingContext sia impostato (probabilmente lo fai in MauiProgram.cs o qui)
         BindingContext = new FittingsViewModel(); 
    }

    // NUOVO METODO PER IL CALCOLO
    private void BtnCalcolaRaccordo_Clicked(object sender, EventArgs e)
    {
        // Vibrazione feedback
        try { Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(50)); } catch { }

        try
        {
            // Selezioni lato A
            string genA = PkGenderA.SelectedItem?.ToString() ?? "Maschio";
            string sizeA = PkSizeA.SelectedItem?.ToString() ?? "1/4\"";
            string typeA = PkTypeA.SelectedItem?.ToString() ?? "GAS";

            // Selezioni lato B
            string genB = PkGenderB.SelectedItem?.ToString() ?? "Femmina";
            string sizeB = PkSizeB.SelectedItem?.ToString() ?? "1/4\"";
            string typeB = PkTypeB.SelectedItem?.ToString() ?? "GAS";

            // LOGICA DI INVERSIONE (Se ho Maschio, mi serve Femmina)
            string reqGenA = (genA == "Maschio") ? "Femmina" : "Maschio";
            string reqGenB = (genB == "Maschio") ? "Femmina" : "Maschio";

            // Determinazione nome tecnico
            string nomePezzo = "ADATTATORE";

            if (reqGenA == "Maschio" && reqGenB == "Maschio")
                nomePezzo = "NIPPLO (M-M)";
            else if (reqGenA == "Femmina" && reqGenB == "Femmina")
                nomePezzo = "MANICOTTO (F-F)";
            else
                nomePezzo = "PROLUNGA/RIDUZIONE (M-F)";

            // Controllo se è una riduzione
            if (sizeA != sizeB) nomePezzo += " RIDOTTO";

            // Costruzione stringa finale
            // Esempio: NIPPLO RIDOTTO
            // M 1/4 GAS - M 3/8 NPT
            LblRisultatoRaccordo.Text = $"{nomePezzo}\n" +
                                        $"Lato A: {reqGenA.Substring(0, 1)} {sizeA} {typeA}  ⟷  " +
                                        $"Lato B: {reqGenB.Substring(0, 1)} {sizeB} {typeB}";
        }
        catch (Exception)
        {
            LblRisultatoRaccordo.Text = "Seleziona tutti i campi!";
        }
    }
}