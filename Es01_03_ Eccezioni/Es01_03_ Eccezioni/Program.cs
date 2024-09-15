using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace Es01_03__Eccezioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using var letturaFile = new FileStream(@"C:\Users\Utente\Desktop\net-iemme-ava\Esercitazioni\Es01_03_ Eccezioni\Es01_03_ Eccezioni\TextFile1.txt", FileMode.Open);
            //using var lettore = new StreamReader(letturaFile);

            //while (!lettore.EndOfStream)
            //{
            //    var line = lettore.ReadLine();
            //    Console.WriteLine(line?.ToUpperInvariant());
            //}

            string[] righe = File.ReadAllLines(@"C:\Users\Utente\Desktop\net-iemme-ava\Esercitazioni\Es01_03_ Eccezioni\Es01_03_ Eccezioni\TextFile1.txt");

            double somma = 0;

            foreach (string riga in righe)
            {
                somma = somma + int.Parse(riga);
            }
            Console.WriteLine($"La somma dei numeri del file è: {somma}");
        }
    }
}
