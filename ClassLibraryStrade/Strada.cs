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
            this.incrocioFine = incrocioFine;
        }
        public Incrocio IncrocioPartenza { get => incrocioPartenza; set => incrocioPartenza = value; }
        public Incrocio IncrocioFine { get => incrocioFine; set => incrocioFine = value; }
    }
}
