using System;
using System.Collections.Generic;
using System.Linq;

namespace Es01_02_ListaStudenti.classes
{
    internal class Università
    {
        public string? Nome { get; set; }
        public string? Indirizzo { get; set; }
        public string? Facoltà { get; set; }

        public List<Studente> Elenco { get; set; } = new List<Studente>();
        public void AggiungiStudente(Studente studente)
        {
            Elenco.Add(studente);
            Console.WriteLine("Studente aggiunto con successo");
        }

        public void StampaElenco()
        {
            Console.WriteLine("Ecco l'elenco degli studenti");
            foreach (Studente studente in Elenco)
                Console.WriteLine(studente.ToString());
        }

        public Studente? TrovaStudentePerNome(string nome)
        {
            return Elenco.FirstOrDefault(s => s.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        public bool EliminaStudente(string nome)
        {
            Studente studenteDaEliminare = Elenco.FirstOrDefault(s => s.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase) || s.Cognome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if (studenteDaEliminare == null)
                return false;

            bool rimosso = Elenco.Remove(studenteDaEliminare);
            return rimosso;
        }

        public void StampaElencoRangeVoti()
        {
            Console.Write("Scegli il voto inferiore: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Scegli il voto superiore: ");
            int max = Convert.ToInt32(Console.ReadLine());
            foreach (Studente studente in Elenco)
            {
                if (studente.Voto >= min && studente.Voto <= max)
                { 
                    Console.WriteLine($"L'elenco degli studenti con voto compreso tra {min} e {max} é:");
                    Console.WriteLine(studente.ToString());
                }
            }
        }
    }
}
