namespace MechTools.Models
{
    public class ConversionItem
    {
        public string Fraction { get; set; } // Es: "1/2"
        public double DecimalInch { get; set; } // Es: 0.500
        public double Mm { get; set; } // Es: 12.70

        // Per la visualizzazione in lista
        public string DisplayText => $"{Fraction}\" ({DecimalInch:F3})  ➜  {Mm:F2} mm";
    }
}