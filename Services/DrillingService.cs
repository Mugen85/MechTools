using MechTools.Models;

namespace MechTools.Services
{
    public static class DrillingService
    {
        private static readonly List<ThreadItem> _threads = new List<ThreadItem>
        {
            // --- PASSO GROSSO (Standard) ---
            new ThreadItem { Name = "M3",  Pitch = 0.5,  DrillMm = 2.5,  IsFinePitch = false },
            new ThreadItem { Name = "M4",  Pitch = 0.7,  DrillMm = 3.3,  IsFinePitch = false },
            new ThreadItem { Name = "M5",  Pitch = 0.8,  DrillMm = 4.2,  IsFinePitch = false },
            new ThreadItem { Name = "M6",  Pitch = 1.0,  DrillMm = 5.0,  IsFinePitch = false },
            new ThreadItem { Name = "M8",  Pitch = 1.25, DrillMm = 6.8,  IsFinePitch = false },
            new ThreadItem { Name = "M10", Pitch = 1.5,  DrillMm = 8.5,  IsFinePitch = false },
            new ThreadItem { Name = "M12", Pitch = 1.75, DrillMm = 10.2, IsFinePitch = false },
            new ThreadItem { Name = "M14", Pitch = 2.0,  DrillMm = 12.0, IsFinePitch = false },
            new ThreadItem { Name = "M16", Pitch = 2.0,  DrillMm = 14.0, IsFinePitch = false },
            new ThreadItem { Name = "M20", Pitch = 2.5,  DrillMm = 17.5, IsFinePitch = false },
            new ThreadItem { Name = "M24", Pitch = 3.0,  DrillMm = 21.0, IsFinePitch = false },

            // --- PASSO FINE (I più comuni) ---
            new ThreadItem { Name = "M8 x 1",    Pitch = 1.0,  DrillMm = 7.0,  IsFinePitch = true },
            new ThreadItem { Name = "M10 x 1",   Pitch = 1.0,  DrillMm = 9.0,  IsFinePitch = true },
            new ThreadItem { Name = "M10 x 1.25",Pitch = 1.25, DrillMm = 8.8,  IsFinePitch = true },
            new ThreadItem { Name = "M12 x 1.25",Pitch = 1.25, DrillMm = 10.8, IsFinePitch = true },
            new ThreadItem { Name = "M12 x 1.5", Pitch = 1.5,  DrillMm = 10.5, IsFinePitch = true },
            new ThreadItem { Name = "M14 x 1.5", Pitch = 1.5,  DrillMm = 12.5, IsFinePitch = true },
            new ThreadItem { Name = "M16 x 1.5", Pitch = 1.5,  DrillMm = 14.5, IsFinePitch = true },
        };

        public static List<ThreadItem> GetAll() => _threads;

        // Filtro rapido
        public static List<ThreadItem> GetStandard() => _threads.Where(t => !t.IsFinePitch).ToList();
        public static List<ThreadItem> GetFine() => _threads.Where(t => t.IsFinePitch).ToList();
    }
}