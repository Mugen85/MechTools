using MechTools.Models;

namespace MechTools.Services
{
    public static class BoltService
    {
        private static readonly List<Bolt> _bolts =
        [
            // Dati standard ISO (Filettatura metrica grossa)
            new Bolt { ThreadSize = "M3",  HexWrenchSize = 5,  AllenWrenchSize = 2,  Pitch = 0.5 },
            new Bolt { ThreadSize = "M4",  HexWrenchSize = 7,  AllenWrenchSize = 3,  Pitch = 0.7 },
            new Bolt { ThreadSize = "M5",  HexWrenchSize = 8,  AllenWrenchSize = 4,  Pitch = 0.8 },
            new Bolt { ThreadSize = "M6",  HexWrenchSize = 10, AllenWrenchSize = 5,  Pitch = 1.0 },
            new Bolt { ThreadSize = "M8",  HexWrenchSize = 13, AllenWrenchSize = 6,  Pitch = 1.25 },
            new Bolt { ThreadSize = "M10", HexWrenchSize = 17, AllenWrenchSize = 8,  Pitch = 1.5 },
            new Bolt { ThreadSize = "M12", HexWrenchSize = 19, AllenWrenchSize = 10, Pitch = 1.75 },
            new Bolt { ThreadSize = "M14", HexWrenchSize = 22, AllenWrenchSize = 12, Pitch = 2.0 },
            new Bolt { ThreadSize = "M16", HexWrenchSize = 24, AllenWrenchSize = 14, Pitch = 2.0 },
            new Bolt { ThreadSize = "M20", HexWrenchSize = 30, AllenWrenchSize = 17, Pitch = 2.5 }
        ];

        public static List<Bolt> GetAllBolts()
        {
            return _bolts;
        }

        // Cerca info partendo dalla vite (es. "M8")
        public static Bolt? GetBoltInfo(string size)
        {
            // Check for null before dereferencing ThreadSize
            return _bolts.FirstOrDefault(b => b.ThreadSize != null && b.ThreadSize.Equals(size, StringComparison.OrdinalIgnoreCase));
        }

        // Cerca info partendo dalla chiave fissa (es. "Chiave del 13")
        public static Bolt? GetBoltByHexWrench(int wrenchSize)
        {
            return _bolts.FirstOrDefault(b => b.HexWrenchSize == wrenchSize);
        }
    }
}