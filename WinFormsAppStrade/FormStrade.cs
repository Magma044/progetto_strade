using ClassLibraryStrade;
using System.Drawing.Text;

namespace WinFormsAppStrade
{
    public partial class FormStrade : Form
    {
        private Random random;
        private Punto[] punti;
        private const int numeroPunti = 30;
        public FormStrade()
        {
            InitializeComponent();
            this.ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.WindowState = FormWindowState.Maximized;
            this.punti = new Punto[numeroPunti];
            random = new Random();
            GeneraPunti();
        }

        private void GeneraPunti()
        {
            for(int i = 0; i < punti.Length; i++)
            {
                int x = random.Next(ClientSize.Width);
                int y = random.Next(ClientSize.Height-50);
                punti[i] = new Punto();
                punti[i].P = new Point(x, y);
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            for(int i=0; i<punti.Length;i++) // per ciclare ogni punto in modo da fare i collegamenti
            {
                List<(double distanza, Point punto)> p = new();
                for(int j=0; j<punti.Length; j++) //prende il punto per collegarlo
                {
                    if (punti[j].P != punti[i].P)
                    {
                        double d = CalcolaDistanza(punti[i].P, punti[j].P);
                        p.Add((d, punti[j].P));
                        punti[i].NumeroMassimoCollegamenti--;
                    }
                }
                // Ordina per distanza crescente
                p.Sort((a, b) => a.distanza.CompareTo(b.distanza));

                // Aggiungi i 2 più vicini
                for (int k = 0; k < 3 && k < p.Count; k++)
                {
                    if (punti[k].NumeroMassimoCollegamenti != 0) punti[i].PuntiCollegati.Add(p[k].punto);
                }
            }

            foreach(var punto in punti)
            {
                g.FillEllipse(Brushes.Red, punto.P.X - 2, punto.P.Y - 2, 5, 5);
                foreach (var collegato in punto.PuntiCollegati)
                {
                    g.DrawLine(Pens.Black, punto.P, collegato);
                }
            }
        }

        private static double CalcolaDistanza(Point a, Point b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
