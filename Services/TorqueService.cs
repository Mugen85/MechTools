using MechTools.Models;

namespace MechTools.Services
{
    public static class TorqueService
    {
        // Dati approssimati standard ISO passo grosso (Coeff 0.14)
        private static readonly List<TorqueRow> _data =
        [
            new TorqueRow { Diameter = "M4",  Val88 = 3,   Val109 = 4,   Val129 = 5 },
            new TorqueRow { Diameter = "M5",  Val88 = 6,   Val109 = 9,   Val129 = 10 },
            new TorqueRow { Diameter = "M6",  Val88 = 10,  Val109 = 15,  Val129 = 18 },
            new TorqueRow { Diameter = "M8",  Val88 = 25,  Val109 = 36,  Val129 = 43 },
            new TorqueRow { Diameter = "M10", Val88 = 49,  Val109 = 72,  Val129 = 84 },
            new TorqueRow { Diameter = "M12", Val88 = 86,  Val109 = 125, Val129 = 145 },
            new TorqueRow { Diameter = "M14", Val88 = 135, Val109 = 200, Val129 = 235 },
            new TorqueRow { Diameter = "M16", Val88 = 210, Val109 = 310, Val129 = 365 },
            new TorqueRow { Diameter = "M18", Val88 = 290, Val109 = 430, Val129 = 500 },
            new TorqueRow { Diameter = "M20", Val88 = 410, Val109 = 610, Val129 = 710 },
            new TorqueRow { Diameter = "M22", Val88 = 550, Val109 = 820, Val129 = 960 },
            new TorqueRow { Diameter = "M24", Val88 = 710, Val109 = 1050, Val129 = 1220 }
        ];

        public static List<TorqueRow> GetData() => _data;
    }
}