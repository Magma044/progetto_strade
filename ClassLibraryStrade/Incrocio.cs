using System.Drawing;

namespace ClassLibraryStrade
{
    public class Incrocio
    {
        private int x;
        private int y;
        private List<Strada> strade;
        private Point? puntoIncrocio;

        public Incrocio(int x, int y)
        {
            this.x = x;
            this.y = y;
            strade = [];
        }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Point PuntoIncrocio
        {
            get
            {
                if (puntoIncrocio == null)
                {
                    puntoIncrocio = new Point(x, y);
                }
                return (Point)puntoIncrocio;
            }
        }

        public double Distanza(Incrocio i)
        {
            int dx = x - i.X;
            int dy = y - i.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void AddStrada(Strada strada)
        {
            if (!strade.Contains(strada))
            {
                strade.Add(strada);
            }
        }
    }
}
