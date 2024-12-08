using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Trabalho_Pratico_Aeds
{
    public class Carta
    {
        public int Numero { get;}
        public string Naipe { get;}


        public Carta(int numero, string naipe)
        {
        Numero = numero;
        Naipe = naipe;
        }   
    }
}
