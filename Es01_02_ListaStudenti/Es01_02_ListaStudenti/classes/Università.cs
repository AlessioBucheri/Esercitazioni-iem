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

        public static void RimuoviStudente(List<Studente> Elenco, string nome, string cognome)
        {
            Elenco.RemoveAll(s => s.Nome == nome && s.Cognome == cognome);
        }

    }
}
