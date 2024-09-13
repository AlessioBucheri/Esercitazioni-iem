using Es01_02_ListaStudenti.classes;
using System.Linq.Expressions;

namespace Es01_02_ListaStudenti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insAbi = true;

            while (insAbi)
            {
                Console.WriteLine("BENVENUTO NEL GESTIONALE STUDENTI\n" +
                    "\n" +
                    "Che operazione vuoi fare?\n" +
                    "1 - Inserire un nuovo studente\n" +
                    "2 - Visualizzare tutti gli studenti\n" +
                    "3 - Modificare i dati di uno studente\n" +
                    "4 - Filtrare e visualizzare gli studenti in base a un intervallo di voti\n" +
                    "5 - Eliminare uno studente dalla lista\n" +
                    "6 - Uscita");
                string? select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        Console.WriteLine("Inserisci il nome");
                        string varNome = Console.ReadLine();
                        Console.WriteLine("Inserisci il cognome");
                        string varCognome = Console.ReadLine();
                        Console.WriteLine("Inserisci il voto");
                        double varVoto = Convert.ToDouble(Console.ReadLine());
                        
                        Studente newStudente = new Studente(varNome, varCognome, varVoto);
                        List<Studente> Elenco = new List<Studente>();
                        Elenco.Add(newStudente);
                        Console.WriteLine("Studente aggiunto con successo!");
                        newStudente.StampaDettaglio();
                        break;
                    case "2":
                        foreach (Studente studente in Elenco)
                            Console.WriteLine(studente.ToString());
                        break;

                }

            }
        }
    }
}
