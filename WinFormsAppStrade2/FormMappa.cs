using ClassLibraryStrade;
using System.Configuration;

namespace WinFormsAppStrade2
{
    public partial class FormMappa : Form
    {
        private Mappa mappa;
        public FormMappa()
        {
            InitializeComponent();
            this.ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.WindowState = FormWindowState.Maximized;

            //Generazione punti incrocio
            List<Incrocio> incroci = [];
            for (int i = 0; i < 35; i++)
            {
                Random r = new Random();
                int x = r.Next(25, ClientSize.Width - 100);
                int y = r.Next(25, ClientSize.Height - 100);
                Incrocio incrocio = new Incrocio(x, y);
                incroci.Add(incrocio);
            }

            //Generazione strade
            List<Strada> strade = [];
            foreach (Incrocio i in incroci)
            {
                double distanza = 9999;
                Incrocio partenza = i;
                Incrocio fine = null;
                foreach(Incrocio j in incroci)
                {
                    if(j != i)
                    {
                        
                        double distanzaAttuale = i.Distanza(j);
                        if (distanzaAttuale < distanza)
                        {
                            distanza = distanzaAttuale;
                            fine = j;
                        }
                    }
                }
                strade.Add(new Strada(partenza, fine));
            }
            mappa = new Mappa(incroci, strade); //Creazione oggetto mappa
        }
        

        //Disegno grafica
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(Incrocio i in mappa.Incroci){
                g.FillEllipse(Brushes.Red, i.X-4, i.Y-4, 8, 8);
            }
            foreach(Strada s in mappa.Strade)
            {
                g.DrawLine(Pens.Black, s.IncrocioPartenza.PuntoIncrocio, s.IncrocioFine.PuntoIncrocio);
            }
        }
    }
}
