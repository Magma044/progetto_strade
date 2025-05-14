using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryStrade
{
    public class Mappa
    {
        private List<Incrocio> incroci = [];
        private List<Strada> strade = [];

        public Mappa(List<Incrocio> incroci, List<Strada> strade)
        {
            this.incroci = incroci;
            this.strade = strade;
        }

        public List<Incrocio> Incroci { get => incroci; set => incroci = value; }
        public List<Strada> Strade { get => strade; set => strade = value; }
    }
}
