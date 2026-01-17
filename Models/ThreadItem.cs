namespace MechTools.Models
{
    public class ThreadItem
    {
        public string Name { get; set; }      // Es: "M8"
        public double Pitch { get; set; }     // Es: 1.25 (Passo)
        public double DrillMm { get; set; }   // Es: 6.8 (Punta da usare)
        public bool IsFinePitch { get; set; } // True = Passo Fine, False = Standard

        // Per la visualizzazione
        public string TypeDescription => IsFinePitch ? "Passo Fine" : "Standard";

        // Colore diverso per distinguere a colpo d'occhio
        public string TypeColor => IsFinePitch ? "#007ACC" : "#FF9900"; // Blu per fine, Arancio per standard
    }
}