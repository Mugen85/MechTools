namespace MechTools.Models
{
    // Definiamo i due standard mondiali
    public enum FittingStandard
    {
        GasBSP, // Europa (Filetto cilindrico, tenuta su guarnizione)
        NPT     // USA (Filetto conico, tenuta sul filetto)
    }

    public class Fitting
    {
        // Esempio: "1/4"
        public string? Name { get; set; }

        // Gas o NPT
        public FittingStandard Type { get; set; }

        // Diametro esterno in mm (quello che misuri col calibro)
        public double OuterDiameterMm { get; set; }

        // Filetti per pollice (da misurare col contafiletti)
        public double TPI { get; set; }

        // Una proprietà di sola lettura che ci serve per visualizzare
        // i dati in modo carino nella lista dell'App
        public string DisplayName => $"{Name} {Type} (Ø {OuterDiameterMm} mm - {TPI} TPI)";
    }
}