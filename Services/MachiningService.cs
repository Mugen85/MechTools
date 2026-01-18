using MechTools.Models;

namespace MechTools.Services
{
    public static class MachiningService
    {
        // Dati conservativi per utensili HSS standard
        private static readonly List<CuttingMaterial> _materials =
        [
            new CuttingMaterial { Name = "Alluminio / Leghe Leggere", Vc = 60, Color = "#E0E0E0" }, // Grigio Chiaro
            new CuttingMaterial { Name = "Ottone / Bronzo",           Vc = 45, Color = "#FFD700" }, // Oro
            new CuttingMaterial { Name = "Ferro / Acciaio Dolce (Fe360)",     Vc = 30, Color = "#007ACC" }, // Blu
            new CuttingMaterial { Name = "Acciaio C40 / Ghisa",       Vc = 25, Color = "#555555" }, // Grigio Scuro
            new CuttingMaterial { Name = "Acciaio Inox (304/316)",    Vc = 15, Color = "#D32F2F" }, // Rosso (Pericolo!)
            new CuttingMaterial { Name = "Titanio / Leghe Dure",      Vc = 10, Color = "#800080" }, // Viola
            new CuttingMaterial { Name = "Plastica / Nylon",          Vc = 50, Color = "#FFFFFF" }  // Bianco
        ];

        public static List<CuttingMaterial> GetMaterials() => _materials;
    }
}