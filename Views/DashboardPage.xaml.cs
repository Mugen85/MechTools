namespace MechTools.Views;

public partial class DashboardPage : ContentPage
{
    // Variabile memoria per sapere se è accesa
    private bool _isFlashlightOn = false;

    // Definizione dei colori per lo stato ON/OFF
    // OFF: Grigio scuro come gli altri tasti (#252525)
    private readonly Color _colorOffBg = Color.FromArgb("#252525");
    // ON: Giallo scuro "acceso" (#333300) - Puoi farlo anche più luminoso se vuoi
    private readonly Color _colorOnBg = Color.FromArgb("#333300");

    public DashboardPage()
    {
        InitializeComponent();
        // Impostiamo lo stato iniziale grafico (OFF)
        UpdateFlashlightUI(false);
    }

    private async void BtnFlashlight_Clicked(object sender, EventArgs e)
    {
        // 1. VIBRAZIONE FORTE (Se abilitata nel telefono)
        try { Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(50)); } catch { }

        // 2. LOGICA ON/OFF
        try
        {
            if (_isFlashlightOn)
            {
                // Se è accesa -> SPEGNI
                await Flashlight.Default.TurnOffAsync();
                _isFlashlightOn = false;
            }
            else
            {
                // Se è spenta -> ACCENDI
                await Flashlight.Default.TurnOnAsync();
                _isFlashlightOn = true;
            }

            // AGGIORNA LA GRAFICA IN BASE AL NUOVO STATO
            UpdateFlashlightUI(_isFlashlightOn);
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Errore", "Nessun flash trovato.", "OK");
        }
        catch (Exception)
        {
            // In caso di errore generico, proviamo a spegnere tutto e resettare
            try { await Flashlight.Default.TurnOffAsync(); } catch { }
            _isFlashlightOn = false;
            UpdateFlashlightUI(false);
        }
    }

    // Metodo ausiliario per tenere pulito il codice.
    // Si occupa solo di aggiornare colori e testo.
    private void UpdateFlashlightUI(bool isOn)
    {
        if (isOn)
        {
            // STATO ACCESO
            BorderTorcia.BackgroundColor = _colorOnBg; // Sfondo Giallastro
            LblTorcia.Text = "TORCIA: ON";
        }
        else
        {
            // STATO SPENTO
            BorderTorcia.BackgroundColor = _colorOffBg; // Sfondo Scuro Trasparente
            LblTorcia.Text = "TORCIA: OFF";
        }
    }

    // --- GLI ALTRI TUOI METODI DI NAVIGAZIONE ---

    private async void BtnKeys_Clicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Default.Perform(HapticFeedbackType.Click); } catch { }
        await Shell.Current.GoToAsync(nameof(KeysPage));
    }

    private async void BtnFittings_Clicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Default.Perform(HapticFeedbackType.Click); } catch { }
        await Shell.Current.GoToAsync(nameof(FittingsPage));
    }

    private async void BtnDrilling_Clicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Default.Perform(HapticFeedbackType.Click); } catch { }
        await Shell.Current.GoToAsync(nameof(DrillingPage));
    }

    private async void BtnTorque_Clicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Default.Perform(HapticFeedbackType.Click); } catch { }
        await Shell.Current.GoToAsync(nameof(TorquePage));
    }

    private async void BtnRpm_Clicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Default.Perform(HapticFeedbackType.Click); } catch { }
        await Shell.Current.GoToAsync(nameof(RpmPage));
    }

    private async void BtnConverter_Clicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Default.Perform(HapticFeedbackType.Click); } catch { }
        await Shell.Current.GoToAsync(nameof(ConvertersPage));
    }
}