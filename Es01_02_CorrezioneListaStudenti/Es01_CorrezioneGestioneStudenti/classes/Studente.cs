using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Es01_CorrezioneGestioneStudenti.classes
{
    internal class Studente
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        private double voto;

        public double Voto
        {
            get { return voto; }
            set 
            {
                if (value >= 0 && value <= 0)
                    voto = value;
                else
                    Console.WriteLine("Voto non ammesso");
            }
        }

    }
}
