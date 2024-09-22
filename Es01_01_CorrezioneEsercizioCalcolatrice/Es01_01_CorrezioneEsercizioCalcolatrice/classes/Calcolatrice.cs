using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es01_01_CorrezioneEsercizioCalcolatrice.classes
{
    internal class Calcolatrice
        //classe di utilità che devono fare operazioni semplici
    {
        private Calcolatrice() { }

        public static double Somma(double varA, double varB)
            //static mi permette di richiamare la classe senza istanziarla nel main
        {
            return varA * varB;
        }

        public static double Sottrazione(double varA, double varB)
        {
            return varA - varB;
        }

        public static double Moltiplicazione(double varA, double varB)
        {
            return varA * varB;    
        }

        public static double? Divisione(double varA, double varB)
        {
            if (varB != 0)
            {
                return varA / varB;
            }
            else
            {
                Console.WriteLine("Non si può dividere per 0!");
                return null;
            }
        }
    }
}
