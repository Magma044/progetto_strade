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
            CollegamentoIsole();
        }

        public List<Incrocio> Incroci { get => incroci; set => incroci = value; }
        public List<Strada> Strade { get => strade; set => strade = value; }

        private void CollegamentoIsole(int index = 0, List<Incrocio>? trovatiFinora = null)
        {
          /*  Incrocio partenza = incroci[index];     //Parto dall'elemento in posizione index


            Incrocio finale = incroci[index + 1];   //Arrivo all'elemento index + 1

            if (trovatiFinora == null)
            {
                trovatiFinora = [partenza];
            } else if (trovatiFinora.Contains(finale))
            {
                //Elemento già visitato

                if (index < incroci.Count)
                {
                    CollegamentoIsole(index + 1, trovatiFinora);
                    return;
                }
                return;
            }*/
            foreach(var i in incroci)
            {
                if (i.Strade.Count == 1)
                {
                    Incrocio incrociomin=null;
                    double distanzamin = double.MaxValue;
                    foreach (var j in incroci)
                    {
                        if (i.Distanza(j) < distanzamin)
                        {
                            incrociomin = j;
                            distanzamin = i.Distanza(j);
                        }
                    }
                    strade.Add(new Strada(i, incrociomin));
                }
                
            }


            //Espansione a grafo

        }
    }
}
