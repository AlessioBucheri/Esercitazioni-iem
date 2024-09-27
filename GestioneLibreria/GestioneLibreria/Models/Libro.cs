using GestioneLibreria.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibreria.Models
{
    internal class Libro
    {
        public int LibroID { get; set; }
        public string CodiceLibro { get; set; } = null!;
        public string Titolo { get; set; } = null!;
        public string AnnoPubblicazione { get; set; }
        public bool IsDisp { get; set; } = true;

        public Libro() { }
        public Libro(string titolo, string anno_pubblicazione, bool isDisp)
        {
            Titolo = titolo;
            AnnoPubblicazione = anno_pubblicazione;
            IsDisp = isDisp;
        }

        public override string ToString()
        {
            return $"[LIBRO]\n" +
                $"Titolo: {Titolo}\n" +
                $"Anno di Pubblicazione: {AnnoPubblicazione}\n" +
                $"Dipsonibilità: {IsDisp}";
        }
        public string StampaDettaglioLibro()
        {
            return $"[LIBRO]\n" +
                $"Titolo: {Titolo}\n" +
                $"Anno di Pubblicazione: {AnnoPubblicazione}\n" +
                $"Dipsonibilità: {IsDisp}";
        }
    }
}
