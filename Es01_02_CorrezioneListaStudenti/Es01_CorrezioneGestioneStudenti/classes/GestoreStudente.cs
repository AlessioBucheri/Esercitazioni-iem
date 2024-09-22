using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es01_CorrezioneGestioneStudenti.classes
{
    internal class GestoreStudente
    {
        private List<Studente> Elenco { get; set; } = new List<Studente>();
        public void ModificaStudente(Studente studente, Studente studenteModificato)
        { 
           foreach (Studente stu in Elenco)
            {
                if (studente.Nome != null &&
                    studente.Nome.Equals(stu.Nome) &&
                    studente.Cognome != null &&
                    studente.Cognome.Equals(stu.Cognome))
                { 
                    stu.Nome = studenteModificato.Nome;
                    stu.Cognome = studenteModificato.Cognome;
                    stu.Voto = studenteModificato.Voto;
                }
            }
        }

        public void IntervalloVoti(double maggioreDi, double minoreDi)
        {
            List<Studente> Filtro = new List<Studente>();

            foreach (Studente stu in Elenco)
            {
                if (stu.Voto >= maggioreDi && stu.Voto <= minoreDi)
                    Filtro.Add(stu);
            }
            foreach (Studente stu in Filtro)
            {
                Console.WriteLine(stu);
            }
        }
    }
}
