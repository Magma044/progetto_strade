using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStrade
{
    public class Mappa
    {
        private List<Incrocio> incroci;
        private List<Strada> strade;

        public Mappa()
        {
            this.incroci = new List<Incrocio>();
            this.strade = new List<Strada>();
        }
        public List<Incrocio> Incroci { get => incroci; set => incroci = value; }
        public List<Strada> Strade { get => strade; set => strade = value; }
    }
}
