using ClassLibraryStrade;
using System.Configuration;

namespace WinFormsAppStrade2
{
    public partial class FormMappa : Form
    {
        Mappa m = new Mappa();
        public FormMappa()
        {
            InitializeComponent();
            this.ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.WindowState = FormWindowState.Maximized;

            //Generazione punti incrocio
            for (int i = 0; i < 10; i++)
            {
                Random r = new Random();
                int x = r.Next(25, ClientSize.Width - 25);
                int y = r.Next(25, ClientSize.Height - 25);
                Incrocio incrocio = new Incrocio(x, y);
                m.Incroci.Add(incrocio);
            }

            //Generazione strade
            foreach(Incrocio i in m.Incroci)
            {
                double distanza = 9999;
                Incrocio partenza = i;
                Incrocio fine = null;
                foreach(Incrocio j in m.Incroci)
                {
                    if(j != i)
                    {
                        int dx = i.X - j.X;
                        int dy = i.Y - j.Y;
                        double distanzaAttuale = Math.Sqrt(dx * dx + dy * dy);
                        if(distanzaAttuale < distanza)
                        {
                            distanza = distanzaAttuale;
                            fine = j;
                        }
                    }
                }
                Strada s = new Strada(partenza, fine);
                m.Strade.Add(s);
            }
        }

        //Disegno grafica
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(Incrocio i in m.Incroci){
                g.FillEllipse(Brushes.Red, i.X, i.Y, 5, 5);
            }
            foreach(Strada s in m.Strade)
            {
                g.DrawLine(Brushes.Black, s.IncrocioPartenza, s.IncrocioFine);
            }
        }
    }
}
