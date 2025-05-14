using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStrade
{
    public class Strada
    {
        private Incrocio incrocioPartenza;
        private Incrocio incrocioFine;

        public Strada(Incrocio incrocioPartenza, Incrocio incrocioFine)
        {
            this.incrocioPartenza = incrocioPartenza;
            incrocioPartenza.AddStrada(this);
            this.incrocioFine = incrocioFine;
            incrocioFine.AddStrada(this);
        }
        public Incrocio IncrocioPartenza { get => incrocioPartenza; set => incrocioPartenza = value; }
        public Incrocio IncrocioFine { get => incrocioFine; set => incrocioFine = value; }

        public double Distanza { get => Math.Sqrt(Math.Pow(incrocioPartenza.X - incrocioFine.X, 2) + Math.Pow(incrocioPartenza.Y - incrocioFine.Y, 2)); }
    }
}
