namespace MechTools.Models
{
    public class CuttingMaterial
    {
        public string? Name { get; set; }  // Es: "Acciaio Inox (304)"
        public int Vc { get; set; }       // Velocità di taglio consigliata (m/min)
        public string? Color { get; set; } // Colore esadecimale per la UI

        // Proprietà helper per il menu a tendina
        public string DisplayName => $"{Name} (Vc: {Vc} m/min)";
    }
}