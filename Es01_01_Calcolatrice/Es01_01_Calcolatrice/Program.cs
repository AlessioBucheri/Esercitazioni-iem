using Es01_01_Calcolatrice.classes;

namespace Es01_01_Calcolatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insAbi = true;
            double inputUtente;
            double inputUtenteDue;

            while (insAbi)
            {
                Console.WriteLine(
                    "------------------------CALCOLATRICE------------------------\n" +
                    "|  Scegli il comando per effettuare l'operazione desiderata|\n" +
                    "|  A - Addizione                                           |\n" +
                    "|  S - Sottrazione                                         |\n" +
                    "|  M - Moltiplicazione                                     |\n" +
                    "|  D - Divisione                                           |\n" +
                    "|  P - Potenza                                             |\n" +
                    "|  R - Radice                                              |\n" +
                    "|  Q - Uscita                                              |\n" +
                    "------------------------------------------------------------\n");
                string? inputOperazione = Console.ReadLine();
                inputOperazione = inputOperazione.ToUpper();

                try
                {
                    switch (inputOperazione)
                    {
                        case "A":
                            Console.WriteLine("Inserisci il primo numero");
                            inputUtente = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Inserisci il secondo numero:");
                            inputUtenteDue = Convert.ToDouble(Console.ReadLine());
                            double somma = Calcolatrice.Somma(inputUtente, inputUtenteDue);
                            Console.WriteLine($"Il risultato è {somma}");
                            break;

                        case "S":
                            Console.WriteLine("Inserisci il primo numero");
                            inputUtente = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Inserisci il secondo numero:");
                            inputUtenteDue = Convert.ToDouble(Console.ReadLine());
                            double sottrazione = Calcolatrice.Sottrazione(inputUtente, inputUtenteDue);
                            Console.WriteLine($"Il risultato è {sottrazione}");
                            break;

                        case "M":
                            Console.WriteLine("Inserisci il primo numero");
                            inputUtente = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Inserisci il secondo numero:");
                            inputUtenteDue = Convert.ToDouble(Console.ReadLine());
                            double moltiplicazione = Calcolatrice.Moltiplicazione(inputUtente, inputUtenteDue);
                            Console.WriteLine($"Il risultato è {moltiplicazione}");
                            break;

                        case "D":
                            Console.WriteLine("Inserisci il numeratore");
                            inputUtente = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Inserisci il denominatore:");
                            inputUtenteDue = Convert.ToDouble(Console.ReadLine());

                            if (inputUtenteDue != 0)
                            {
                                double divisione = (double)Calcolatrice.Divisione(inputUtente, inputUtenteDue);
                                Console.WriteLine($"Il risultato è {divisione}");
                            }
                            else
                            {
                                Console.WriteLine("Non si può dividere per 0!");
                            }
                            break;

                        case "P":
                            Console.WriteLine("Inserisci il numero da elevare a potenza");
                            inputUtente = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Inserisci il grado della potenza:");
                            inputUtenteDue = Convert.ToDouble(Console.ReadLine());
                            double potenza = Math.Pow(inputUtente, inputUtenteDue);
                            Console.WriteLine($"La potenza di {inputUtente} elevato a {inputUtenteDue} è: {potenza}");
                            break;

                        case "R":
                            Console.WriteLine("Inserisci il numero");
                            inputUtente = Convert.ToDouble(Console.ReadLine());
                            double radice = Math.Sqrt(inputUtente);
                            Console.WriteLine($"La radice quadrata di {inputUtente} è: {radice}");
                            break;

                        case "Q":
                            Console.WriteLine("Stai uscendo");
                            insAbi = !insAbi;
                            break;

                        default:
                            Console.WriteLine("Operazione non valida!");
                            break;
                    }
                }

                catch
                {
                    Console.WriteLine("Formato non riconosciuto");
                }
            }
        }
    }
}
