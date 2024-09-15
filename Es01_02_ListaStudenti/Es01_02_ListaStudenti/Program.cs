using Es01_02_ListaStudenti.classes;
using System;

namespace Es01_02_ListaStudenti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insAbi = true;
            Università uni = new Università();

            #region INIZIO GESTIONALE STUDENTI
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
                    "Q - Uscita");
                string? select = Console.ReadLine();

                switch (select)
                {
                    #region 1 - AGGIUNTA STUDENTE
                    case "1":                        
                            Console.Write("Inserisci il nome: ");
                            string varNome = Console.ReadLine();
                            Console.Write("Inserisci il cognome: ");
                            string varCognome = Console.ReadLine();
                            Console.Write("Inserisci il voto: ");
                            double varVoto = Convert.ToDouble(Console.ReadLine());
                            if (varNome != "" && varCognome != "" && varVoto >= 0 && varVoto <= 10) //verifica del voto inserito in input
                            {
                                Studente studente = new Studente(varNome, varCognome, varVoto);
                                uni.AggiungiStudente(studente);
                            }
                            else
                            {
                                Console.WriteLine("I dati non sono validi");
                                Console.WriteLine("Inserimento non andato a buon fine");
                            }
                        break;
                    #endregion
                    #region 2 - STAMPA ELENCO
                    case "2":
                        uni.StampaElenco();
                        break;
                    #endregion
                    #region 3 - MODIFICA DATI STUDENTE
                    case "3":
                        Console.Write("Inserisci il nome dello studente da modificare: ");
                        string? nomeDaModificare = Console.ReadLine();
                        Studente? studenteDaModificare = uni.TrovaStudentePerNome(nomeDaModificare);

                        if (studenteDaModificare != null && nomeDaModificare != null)
                        {
                            Console.WriteLine("Cosa vuoi modificare?\n" +
                                "N - Nome\n" +
                                "C - Cognome\n" +
                                "V - Voto\n" +
                                "Q - Uscita");
                            string modificaScelta = Console.ReadLine();
                            modificaScelta = modificaScelta.ToUpper();

                            switch (modificaScelta)
                            {
                                case "N":
                                    Console.Write("Nuovo nome: ");
                                    string? nuovoNome = Console.ReadLine();
                                    studenteDaModificare.Nome = nuovoNome;
                                    break;
                                case "C":
                                    Console.Write("Nuovo cognome: ");
                                    string? nuovoCognome = Console.ReadLine();
                                    studenteDaModificare.Cognome = nuovoCognome;
                                    break;
                                case "V":
                                    Console.Write("Nuovo voto: ");
                                    if (double.TryParse(Console.ReadLine(), out double nuovoVoto) && nuovoVoto >= 0 && nuovoVoto <= 10)
                                    {
                                        studenteDaModificare.Voto = nuovoVoto;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il voto deve essere compreso tra 0 e 10");
                                    }
                                    break;
                                case "Q":
                                    break;
                            }

                            Console.WriteLine("Modifica completata.");
                        }
                        else
                        {
                            Console.WriteLine("Studente non trovato.");
                        }
                        break;
                    #endregion
                    #region 5 - ELIMINAZIONE STUDENTE
                    case "5":
                        Console.Write("Inserisci il nome dello studente da eliminare: ");
                        string? studenteDaEliminare = Console.ReadLine();

                        if (studenteDaEliminare != null)
                        {
                            bool risultato = uni.EliminaStudente(studenteDaEliminare);
                            if (risultato)
                            {
                                Console.WriteLine("Studente eliminato con successo.");
                            }
                            else
                            {
                                Console.WriteLine("Studente non trovato o nome non valido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nome dello studente non valido.");
                        }
                        break;
                    #endregion
                    #region  Q - CHIUSURA GESTIONALE
                    case "Q":
                        insAbi = !insAbi;
                        Console.WriteLine("Gestionale chiuso");
                        break;
                    #endregion
                    #region CASO DI DEFAULT
                    default:
                        Console.WriteLine("Scelta non valida, riprova!");
                        break;
                    #endregion
                }
            }
        }
        #endregion FINE GESTIONALE STUDENTI

    }
}
