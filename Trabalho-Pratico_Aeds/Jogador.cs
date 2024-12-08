using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Trabalho_Pratico_Aeds
{
    public class Jogador
    {
        public string Nome { get; }
        public int Posicao { get; set; }
        public int QuantidadeCartas => pilhaPrincipal.Count;
        public Stack<Carta> pilhaPrincipal { get; } = new Stack<Carta>();
        public Queue<int> HistoricoPosicoes { get; } = new Queue<int>(5);
    
        public Jogador(string nome)
        {
            Nome = nome;
        }
    
        public void Roubar(Jogador jogador)
        {
            while (jogador.pilhaPrincipal.Count > 0)
            {
                pilhaPrincipal.Push(jogador.pilhaPrincipal.Pop());
            }
        }
    
        public void AdicionarRanking(int posicao)
        {
            if (HistoricoPosicoes.Count == 5)
            {
                HistoricoPosicoes.Dequeue();
            }
            HistoricoPosicoes.Enqueue(posicao);
        }
    }
}
