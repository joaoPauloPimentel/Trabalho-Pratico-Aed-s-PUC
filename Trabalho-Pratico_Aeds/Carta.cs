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


        public Carta(int numero)
        {
            Random rd = new Random();
            Numero = numero;
            int randomNumero = rd.Next(0,5);
            if (randomNumero == 0){
                Naipe = "Espadas";
            }
            else if (randomNumero == 1){
                Naipe = "Paus";
            }
            else if (randomNumero == 2){
                Naipe = "Copas";
            }
            else if (randomNumero == 3){
                Naipe = "Ouros";
            }
            

            
        }








        
    }
}
