using GestioneLibreria.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibreria.Models
{
    internal class Prestito
    {
        public int PrestitoID { get; set; }
        public string CodicePrestito { get; set; } = null!;
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public int UtenteRIF { get; set; }
        public int LibroRIF { get; set; }
        public List<Libro>? Libros { get; set; } = null;
        public List<Utente>? Utentes { get; set; } = null;

        public Prestito() { }
        public Prestito(DateTime dataInizio, DateTime dataFine, int utenteRIF, int libroRIF)
        { 
            DataInizio = dataInizio;
            DataFine = dataFine;
            UtenteRIF = utenteRIF;
            LibroRIF = libroRIF;
        }

         public override string ToString()
        {
            int utenteRIF = UtenteRIF;
            int libroRIF = LibroRIF;
           
            return $"[PRESTITO]\n" +
                $"Codice Prestito: {CodicePrestito}\n" +
                $"Data Inizio Prestito: {DataInizio}\n" +
                $"Data Fine Prestito: {DataFine}\n" +
                $"Utente: {utenteRIF}\n" +
                $"Libro: {libroRIF}";
        }
    }
}
