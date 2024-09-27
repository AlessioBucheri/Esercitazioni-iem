using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibreria.Models
{
    internal class Utente
    {
        public int UtenteID { get; set; }
        public string CodiceUtente { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string Email { get; set; } = null!;

        public Utente() { }
        public Utente(string nome, string cognome, string email)
        { 
            Nome = nome;
            Cognome = cognome;
            Email = email;
        }
        public override string ToString()
        {
            return $"[UTENTE]\n" +
                $"Nome: {Nome}\n" +
                $"Cognome: {Cognome}\n" +
                $"Email: {Email}";
        }
        public string StampaDettaglioUtente()
        {
            return $"[UTENTE]\n" +
                $"Nome: {Nome}\n" +
                $"Cognome: {Cognome}\n" +
                $"Email: {Email}";
        }
    }
}
