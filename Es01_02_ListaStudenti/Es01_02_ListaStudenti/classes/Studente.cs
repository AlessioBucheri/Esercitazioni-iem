using System;

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

        public override string ToString()
        {
            return $"[STUDENTE]\n" +
                $"- Nome: {Nome}\n" +
                $"- Cognome: {Cognome}\n" +
                $"- Voto:{Voto}\n" +
                $"|----------------------|";
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
