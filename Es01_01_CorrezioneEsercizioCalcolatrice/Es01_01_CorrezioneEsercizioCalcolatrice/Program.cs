using Es01_01_CorrezioneEsercizioCalcolatrice.classes;

namespace Es01_01_CorrezioneEsercizioCalcolatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double prova = Calcolatrice.Somma(5, 6);
            //Calcolatrice. si chiama metodo di invocazione della classe
            Console.WriteLine(prova);

        }
    }
}
