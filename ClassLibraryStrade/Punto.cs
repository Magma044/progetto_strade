using System.Drawing;

namespace ClassLibraryStrade
{
    public class Punto
    {
        private Point p;
        private List<Point> puntiCollegati;
        private int numeroMassimoCollegamenti;

        public Punto()
        {
            this.puntiCollegati = [];
            this.numeroMassimoCollegamenti = 4;
        }

        public Point P { get => p; set => p = value; }
        public List<Point> PuntiCollegati { get => puntiCollegati; set => puntiCollegati = value; }
        public int NumeroMassimoCollegamenti { get => numeroMassimoCollegamenti; set => numeroMassimoCollegamenti = value; }
    }
}
