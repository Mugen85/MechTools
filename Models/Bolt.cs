namespace MechTools.Models
{
    public class Bolt
    {
        // Esempio: "M8"
        public string? ThreadSize { get; set; }

        // Chiave fissa / stella (Esagono esterno)
        // Esempio: 13 (mm)
        public int HexWrenchSize { get; set; }

        // Chiave a brugola / TCEI (Esagono interno)
        // Esempio: 6 (mm)
        public int AllenWrenchSize { get; set; }

        // Passo standard (utile info extra)
        // Esempio: 1.25
        public double Pitch { get; set; }
    }
}