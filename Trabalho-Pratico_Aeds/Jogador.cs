using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Trabalho_Pratico_Aeds
{
    public class Jogador
    {
        private string nome;
        private int Posicao { get; set; }
        private string Nome;
        public string _Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        

        public Stack<Carta> pilhaPrincipal = new Stack<Carta>();


        public Jogador(string nome){
            Nome = nome;
        } 
        public void Roubar(Jogador jogador){
            
            while(true){
                if(jogador.pilhaPrincipal.Count == 0){
                    break;
                }
                pilhaPrincipal.Push(jogador.pilhaPrincipal.Pop());
            }

            
            
        }



    }
}