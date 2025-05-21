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
            this.incroci = incroci.OrderBy(incroci => incroci.X).ToList();  //Riordino la lista di incroci basandomi sulla coordinata X
            this.strade = strade;
            CollegamentoIsole();
        }

        public List<Incrocio> Incroci { get => incroci; set => incroci = value; }
        public List<Strada> Strade { get => strade; set => strade = value; }

        /**
         * <summary>Metodo per il collegamento delle isole nella generazione casuale
         * Risultato: esiste una sola strada via per raggiungere un posto</summary>
         */
        private void CollegamentoIsole()
        {

            //Prima chiamata: popolo la lista collegatiFinora con il primo incrocio
            List<Incrocio> collegatiFinora = [];
            collegatiFinora.Add(incroci[0]);

            //Espando il grafo a partire dal primo incrocio
            incroci[0].EspandiGrafo(collegatiFinora);

            //A questo punto: un grafo con tutti gli incroci collegati al primo incrocio

            foreach (Incrocio incrocio in incroci)
            {
                if (!collegatiFinora.Contains(incrocio))
                {
                    //Incrocio non collegato
                    //Gestisco un altro grafo
                    List<Incrocio> nuovoGrafo = [];
                    nuovoGrafo.Add(incrocio);
                    incrocio.EspandiGrafo(nuovoGrafo);

                    //Collego i due grafi
                    CollegaGrafi(collegatiFinora, nuovoGrafo);


                }
            }

        }
        /**
         * <summary>Collega due grafi, uno principale e uno secondario, creando la strada con la distanza
         * minima tra i due grafi</summary>
         */
        private List<Incrocio> CollegaGrafi(List<Incrocio> grafoPrincipale, List<Incrocio> grafoSecondario)
        {
            //Collego i due grafi
            double distanza = 9999;
            Incrocio partenza = null;
            Incrocio fine = null;
            foreach (Incrocio i in grafoPrincipale)
            {
                foreach (Incrocio j in grafoSecondario)
                {
                    double distanzaAttuale = i.Distanza(j);
                    if (distanzaAttuale < distanza)
                    {
                        distanza = distanzaAttuale;
                        partenza = i;
                        fine = j;
                    }
                }
            }
            Strada stradaCollegamento = new Strada(partenza, fine);
            strade.Add(stradaCollegamento);

            //Popolo il grafo principale con il grafo secondario
            foreach (Incrocio i in grafoSecondario)
            {
                if (!grafoPrincipale.Contains(i))
                {
                    grafoPrincipale.Add(i);
                }
            }

            //Se necessario, ritorno il grafo principale
            return grafoPrincipale;

        }
    }
}
