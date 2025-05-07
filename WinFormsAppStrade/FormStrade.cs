using System.Drawing.Text;

namespace WinFormsAppStrade
{
    public partial class FormStrade : Form
    {
        private Random random;
        private Point[] punti;
        private const int numeroPunti = 20;
        public FormStrade()
        {
            InitializeComponent();
            this.ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.WindowState = FormWindowState.Maximized;
            random = new Random();
            punti = new Point[numeroPunti];
            GeneraPunti();
        }

        private void GeneraPunti()
        {
            for(int i = 0; i < punti.Length; i++)
            {
                int x = random.Next(ClientSize.Width);
                int y = random.Next(ClientSize.Height-50);
                punti[i] = new Point(x, y);
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            for(int i = 0; i < punti.Length - 1; i++)
            {
                g.DrawLine(Pens.Black, punti[i], punti[i + 1]);
            }

            foreach(var punto in punti)
            {
                g.FillEllipse(Brushes.Red, punto.X - 2, punto.Y - 2, 5, 5);
            }
        }
    }
}
