namespace MechTools.Models
{
    public class TorqueRow
    {
        public string? Diameter { get; set; } // Es: "M8"

        // Valori in Nm (Newton Metro)
        public int Val88 { get; set; }  // Classe 8.8 (Standard)
        public int Val109 { get; set; } // Classe 10.9 (Dure)
        public int Val129 { get; set; } // Classe 12.9 (Durissime)

        // COLORI AD ALTO CONTRASTO PER SFONDO SCURO
        // 8.8 = Bianco/Grigio Chiaro
        public string Color88 => "#FFFFFF";

        // 10.9 = Giallo Oro Acceso
        public string Color109 => "#FFD700";

        // 12.9 = Rosso/Arancio Neon (Visibilissimo sul nero)
        public string Color129 => "#FF4500";
    }
}