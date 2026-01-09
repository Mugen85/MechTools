using MechTools.Models;

namespace MechTools.Services
{
    public static class FittingService
    {
        // Lista privata statica: la nostra "banca dati"
        private static readonly List<Fitting> _fittings =
        [
            // --- GAS (BSP) - Cilindrici ---
            new Fitting { Name = "1/8\"", Type = FittingStandard.GasBSP, OuterDiameterMm = 9.73, TPI = 28 },
            new Fitting { Name = "1/4\"", Type = FittingStandard.GasBSP, OuterDiameterMm = 13.16, TPI = 19 },
            new Fitting { Name = "3/8\"", Type = FittingStandard.GasBSP, OuterDiameterMm = 16.66, TPI = 19 },
            new Fitting { Name = "1/2\"", Type = FittingStandard.GasBSP, OuterDiameterMm = 20.95, TPI = 14 },
            new Fitting { Name = "3/4\"", Type = FittingStandard.GasBSP, OuterDiameterMm = 26.44, TPI = 14 },
            new Fitting { Name = "1\"",   Type = FittingStandard.GasBSP, OuterDiameterMm = 33.25, TPI = 11 },

            // --- NPT (National Pipe Taper) - Conici ---
            new Fitting { Name = "1/8\"", Type = FittingStandard.NPT, OuterDiameterMm = 10.29, TPI = 27 },
            new Fitting { Name = "1/4\"", Type = FittingStandard.NPT, OuterDiameterMm = 13.72, TPI = 18 },
            new Fitting { Name = "3/8\"", Type = FittingStandard.NPT, OuterDiameterMm = 17.15, TPI = 18 },
            new Fitting { Name = "1/2\"", Type = FittingStandard.NPT, OuterDiameterMm = 21.34, TPI = 14 },
            new Fitting { Name = "3/4\"", Type = FittingStandard.NPT, OuterDiameterMm = 26.67, TPI = 14 },
            new Fitting { Name = "1\"",   Type = FittingStandard.NPT, OuterDiameterMm = 33.40, TPI = 11.5 } // Nota il mezzo filetto!
        ];

        // Metodo 1: Restituisce la lista completa
        public static List<Fitting> GetAllFittings()
        {
            return _fittings;
        }

        // Metodo 2: Restituisce solo un tipo specifico (es. solo i Gas)
        public static List<Fitting> GetFittingsByType(FittingStandard type)
        {
            // LINQ: "Dove (Where) il tipo è uguale a 'type', trasformalo in Lista"
            return [.. _fittings.Where(f => f.Type == type)];
        }

        // Metodo 3: Logica per capire se è Gas o NPT misurando punta e fondo
        public static string AnalyzeThread(double tipMm, double bottomMm)
        {
            double diff = Math.Abs(bottomMm - tipMm);

            // Se la differenza è minima (meno di 0.3mm), è cilindrico
            if (diff < 0.3)
                return "GAS (BSP) - Cilindrico";

            // Se c'è differenza significativa, è conico
            return "NPT - Conico";
        }
    }
}