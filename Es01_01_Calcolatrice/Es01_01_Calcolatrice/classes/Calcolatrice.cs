using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es01_01_Calcolatrice.classes
{
    internal abstract class Calcolatrice
    {
        int a;
        int b;
        public int Somma()
        {
            return a + b;
        }
        
    }
}
