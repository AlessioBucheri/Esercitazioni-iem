using System;

namespace Es01_02_ListaStudenti.classes
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
    }
}
