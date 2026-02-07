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
            new Fitting { Name = "1\" 1/4", Type = FittingStandard.GasBSP, OuterDiameterMm = 41.91, TPI = 11 },
            new Fitting { Name = "1\" 1/2", Type = FittingStandard.GasBSP, OuterDiameterMm = 47.80, TPI = 11 },
            new Fitting { Name = "2\"",     Type = FittingStandard.GasBSP, OuterDiameterMm = 59.61, TPI = 11 },

            // --- NPT (National Pipe Taper) - Conici ---
            new Fitting { Name = "1/8\"", Type = FittingStandard.NPT, OuterDiameterMm = 10.29, TPI = 27 },
            new Fitting { Name = "1/4\"", Type = FittingStandard.NPT, OuterDiameterMm = 13.72, TPI = 18 },
            new Fitting { Name = "3/8\"", Type = FittingStandard.NPT, OuterDiameterMm = 17.15, TPI = 18 },
            new Fitting { Name = "1/2\"", Type = FittingStandard.NPT, OuterDiameterMm = 21.34, TPI = 14 },
            new Fitting { Name = "3/4\"", Type = FittingStandard.NPT, OuterDiameterMm = 26.67, TPI = 14 },
            new Fitting { Name = "1\"",   Type = FittingStandard.NPT, OuterDiameterMm = 33.40, TPI = 11.5 },
            new Fitting { Name = "1\" 1/4", Type = FittingStandard.NPT, OuterDiameterMm = 42.16, TPI = 11.5 },
            new Fitting { Name = "1\" 1/2", Type = FittingStandard.NPT, OuterDiameterMm = 48.26, TPI = 11.5 },
            new Fitting { Name = "2\"",     Type = FittingStandard.NPT, OuterDiameterMm = 60.33, TPI = 11.5 },

            // --- JIC 37° (SAE J514) - Filetto UNF/UN (Dritto) ---
            // Nota: Il diametro esterno è quello del filetto MASCHIO
            new Fitting { Name = "JIC -4 (7/16-20)",  Type = FittingStandard.JIC, OuterDiameterMm = 11.11, TPI = 20 },
            new Fitting { Name = "JIC -5 (1/2-20)",   Type = FittingStandard.JIC, OuterDiameterMm = 12.70, TPI = 20 },
            new Fitting { Name = "JIC -6 (9/16-18)",  Type = FittingStandard.JIC, OuterDiameterMm = 14.28, TPI = 18 },
            new Fitting { Name = "JIC -8 (3/4-16)",   Type = FittingStandard.JIC, OuterDiameterMm = 19.05, TPI = 16 },
            new Fitting { Name = "JIC -10 (7/8-14)",  Type = FittingStandard.JIC, OuterDiameterMm = 22.22, TPI = 14 },
            new Fitting { Name = "JIC -12 (1.1/16-12)", Type = FittingStandard.JIC, OuterDiameterMm = 26.98, TPI = 12 },
            new Fitting { Name = "JIC -14 (1.3/16-12)", Type = FittingStandard.JIC, OuterDiameterMm = 30.16, TPI = 12 },
            new Fitting { Name = "JIC -16 (1.5/16-12)", Type = FittingStandard.JIC, OuterDiameterMm = 33.33, TPI = 12 },
            new Fitting { Name = "JIC -20 (1.5/8-12)",  Type = FittingStandard.JIC, OuterDiameterMm = 41.27, TPI = 12 },
            new Fitting { Name = "JIC -24 (1.7/8-12)",  Type = FittingStandard.JIC, OuterDiameterMm = 47.62, TPI = 12 },
            new Fitting { Name = "JIC -32 (2.1/2-12)",  Type = FittingStandard.JIC, OuterDiameterMm = 63.50, TPI = 12 }
        ];

        // Metodo 1: Restituisce la lista completa
        public static List<Fitting> GetAllFittings()
        {
            return _fittings;
        }

        // Metodo 2: Restituisce solo un tipo specifico
        public static List<Fitting> GetFittingsByType(FittingStandard type)
        {
            return [.. _fittings.Where(f => f.Type == type)];
        }

        // Metodo 3: Logica AVANZATA per trovare la misura esatta
        public static string AnalyzeThread(double tipMm, double bottomMm)
        {
            // 1. Calcoliamo la conicità
            double taper = Math.Abs(bottomMm - tipMm);
            bool isTapered = taper > 0.6;

            // 2. Prendiamo il diametro maggiore come riferimento
            double measuredMax = Math.Max(tipMm, bottomMm);

            // 3. Cerchiamo nella lista il raccordo più vicino (GAS, NPT o JIC)
            var bestMatch = _fittings
                .Select(f => new
                {
                    Fitting = f,
                    Delta = Math.Abs(f.OuterDiameterMm - measuredMax)
                })
                .OrderBy(x => x.Delta)
                .FirstOrDefault();

            // 4. Controllo di sicurezza
            if (bestMatch == null || bestMatch.Delta > 1.5)
            {
                return "Misura non trovata in tabella standard.";
            }

            var f = bestMatch.Fitting;

            // 5. Controlli specifici per ambiguità GAS/NPT
            // (I JIC sono dritti, quindi se isTapered è true, non dovrebbe essere JIC)

            if (f.Type == FittingStandard.GasBSP && isTapered)
            {
                return $"⚠️ ATTENZIONE: Diametro da {f.Name} GAS, ma sembra CONICO (NPT?)";
            }

            if (f.Type == FittingStandard.NPT && !isTapered)
            {
                return $"⚠️ ATTENZIONE: Diametro da {f.Name} NPT, ma sembra CILINDRICO (GAS?)";
            }

            // Risultato perfetto
            return $"Rilevato: {f.Name} {f.Type} (Ø Nominale {f.OuterDiameterMm}mm)";
        }
    }
}