using MechTools.Models;
using System.Collections.Generic;
using System.Linq;

namespace MechTools.Services
{
    public static class BoltService
    {
        private static readonly List<Bolt> _bolts =
        [
            // --- PICCOLI E MEDI ---
            new Bolt { ThreadSize = "M3",  HexWrenchSize = 5,  AllenWrenchSize = 2,  Pitch = 0.5 },
            new Bolt { ThreadSize = "M4",  HexWrenchSize = 7,  AllenWrenchSize = 3,  Pitch = 0.7 },
            new Bolt { ThreadSize = "M5",  HexWrenchSize = 8,  AllenWrenchSize = 4,  Pitch = 0.8 },
            new Bolt { ThreadSize = "M6",  HexWrenchSize = 10, AllenWrenchSize = 5,  Pitch = 1.0 },
            new Bolt { ThreadSize = "M8",  HexWrenchSize = 13, AllenWrenchSize = 6,  Pitch = 1.25 },
            new Bolt { ThreadSize = "M10", HexWrenchSize = 17, AllenWrenchSize = 8,  Pitch = 1.5 },
            new Bolt { ThreadSize = "M12", HexWrenchSize = 19, AllenWrenchSize = 10, Pitch = 1.75 },
            new Bolt { ThreadSize = "M14", HexWrenchSize = 22, AllenWrenchSize = 12, Pitch = 2.0 },
            new Bolt { ThreadSize = "M16", HexWrenchSize = 24, AllenWrenchSize = 14, Pitch = 2.0 },
            new Bolt { ThreadSize = "M18", HexWrenchSize = 27, AllenWrenchSize = 14, Pitch = 2.5 }, // M18 a volte utile
            new Bolt { ThreadSize = "M20", HexWrenchSize = 30, AllenWrenchSize = 17, Pitch = 2.5 },

            // --- PESANTI (Macchine movimento terra, Strutture) ---
            // Nota: Le brugole (TCEI) per queste misure saltano alcuni numeri o sono speciali.
            // Ho messo '0' dove la brugola non è standard/comune.
            
            new Bolt { ThreadSize = "M22", HexWrenchSize = 32, AllenWrenchSize = 0,  Pitch = 2.5 },
            new Bolt { ThreadSize = "M24", HexWrenchSize = 36, AllenWrenchSize = 19, Pitch = 3.0 },
            new Bolt { ThreadSize = "M27", HexWrenchSize = 41, AllenWrenchSize = 0,  Pitch = 3.0 },
            new Bolt { ThreadSize = "M30", HexWrenchSize = 46, AllenWrenchSize = 22, Pitch = 3.5 },
            new Bolt { ThreadSize = "M33", HexWrenchSize = 50, AllenWrenchSize = 0,  Pitch = 3.5 },
            new Bolt { ThreadSize = "M36", HexWrenchSize = 55, AllenWrenchSize = 27, Pitch = 4.0 },
            new Bolt { ThreadSize = "M39", HexWrenchSize = 60, AllenWrenchSize = 0,  Pitch = 4.0 },
            new Bolt { ThreadSize = "M42", HexWrenchSize = 65, AllenWrenchSize = 32, Pitch = 4.5 },
            new Bolt { ThreadSize = "M45", HexWrenchSize = 70, AllenWrenchSize = 0,  Pitch = 4.5 },
            new Bolt { ThreadSize = "M48", HexWrenchSize = 75, AllenWrenchSize = 36, Pitch = 5.0 },
            
            // M50 non è standard preferenziale ISO (si salta a M52), ma esiste
            new Bolt { ThreadSize = "M50", HexWrenchSize = 75, AllenWrenchSize = 0,  Pitch = 5.0 }, // Spesso chiave uguale a M48 o speciale
            new Bolt { ThreadSize = "M52", HexWrenchSize = 80, AllenWrenchSize = 0,  Pitch = 5.0 }
        ];

        public static List<Bolt> GetAllBolts()
        {
            return _bolts;
        }

        public static Bolt GetBoltInfo(string size)
        {
            return _bolts.FirstOrDefault(b => b.ThreadSize.Equals(size, StringComparison.OrdinalIgnoreCase));
        }

        public static Bolt GetBoltByHexWrench(int wrenchSize)
        {
            return _bolts.FirstOrDefault(b => b.HexWrenchSize == wrenchSize);
        }
    }
}