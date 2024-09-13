using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es01_02_ListaStudenti.classes
{
    internal class Studente
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public double Voto { get; set; }
        public Studente() { }
        public Studente(string nome, string cognome, double voto)
        {
            Nome = nome;
            Cognome = cognome;
            Voto = voto;
        }

        public void StampaDettaglio()
        {
            Console.WriteLine($"[STUDENTE]\n" +
                $"Nome: {Nome}\n" +
                $"Cognome: {Cognome}\n" +
                $"Voto: {Voto}");
        }
    }
}
