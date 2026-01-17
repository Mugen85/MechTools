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

        // Metodo 3: Logica AVANZATA per trovare la misura esatta
        public static string AnalyzeThread(double tipMm, double bottomMm)
        {
            // 1. Calcoliamo la conicità (Differenza tra fondo e punta)
            double taper = Math.Abs(bottomMm - tipMm);
            bool isTapered = taper > 0.6; // Se c'è più di 0.6mm di differenza, è sicuramente conico

            // 2. Prendiamo il diametro maggiore come riferimento (il fondo del filetto)
            double measuredMax = Math.Max(tipMm, bottomMm);

            // 3. Cerchiamo nella lista il raccordo con il diametro più vicino
            // Usiamo LINQ per ordinare la lista in base alla differenza di diametro
            var bestMatch = _fittings
                .Select(f => new
                {
                    Fitting = f,
                    Delta = Math.Abs(f.OuterDiameterMm - measuredMax)
                })
                .OrderBy(x => x.Delta) // Ordina dal più simile al meno simile
                .FirstOrDefault();

            // 4. Controllo di sicurezza: se il più vicino è comunque lontano più di 1.5mm, non è un raccordo standard
            if (bestMatch == null || bestMatch.Delta > 1.5)
            {
                return "Misura non trovata in tabella standard.";
            }

            var f = bestMatch.Fitting;

            // 5. Raffinatezza: Se le misure sono ambigue (es. 1/2 GAS e 1/2 NPT sono simili),
            // usiamo la conicità misurata per decidere meglio.
            string detectedType = f.Type.ToString();

            // Se il diametro dice GAS, ma noi abbiamo misurato un cono evidente -> Avvisa l'utente
            if (f.Type == FittingStandard.GasBSP && isTapered)
            {
                return $"⚠️ ATTENZIONE: Diametro da {f.Name} GAS, ma sembra CONICO (NPT?)";
            }

            // Se il diametro dice NPT, ma è dritto -> Avvisa l'utente
            if (f.Type == FittingStandard.NPT && !isTapered)
            {
                return $"⚠️ ATTENZIONE: Diametro da {f.Name} NPT, ma sembra CILINDRICO (GAS?)";
            }

            // Risultato perfetto
            return $"Rilevato: {f.Name} {f.Type} (Ø Nominale {f.OuterDiameterMm}mm)";
        }
    }
}