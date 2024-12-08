using System;
using System.Collections.Generic;
using System.Linq;

namespace Trabalho_Pratico_Aeds
{
    class Program
    {
        static void Main(string[] args)
        {
            int valorMinimo = 0;
            bool repetei = true;
            Random random = new Random();
            string repete = "s";

            while (repete == "s")
            {
                Console.WriteLine("Quantos jogadores vão jogar?");
                int index = int.Parse(Console.ReadLine());

                List<Jogador> jogadors = new List<Jogador>();

                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine($"Jogador {i + 1}, digite seu nome:");
                    jogadors.Add(new Jogador(Console.ReadLine()));
                }

                Console.WriteLine("Quantas cartas terá no monte?");
                int quantCartas = int.Parse(Console.ReadLine());

                Stack<Carta> cartas = new Stack<Carta>();
                
                for (int i = 0; i < quantCartas; i++)
                {
                    cartas.Push(new Carta(random.Next(1, 14))); 
                }

                List<Carta> areaDescarte = new List<Carta>(); 

                
                while (cartas.Count > 0)
                {
                    foreach (var jogador in jogadors)
                    {
                        if (cartas.Count == 0)
                            break;

                        Carta cartaDaVez = cartas.Pop();
                        Console.WriteLine($"{jogador.Nome} retirou a carta {cartaDaVez.Numero}");

                        
                        Jogador jogadorRoubar = null;
                        foreach (var outroJogador in jogadors)
                        {
                            if (outroJogador != jogador && outroJogador.pilhaPrincipal.Count > 0 && cartaDaVez.Numero == outroJogador.pilhaPrincipal.Peek().Numero)
                            {
                                if (jogadorRoubar == null || outroJogador.pilhaPrincipal.Count > jogadorRoubar.pilhaPrincipal.Count)
                                {
                                    jogadorRoubar = outroJogador;
                                }
                            }
                        }

                        if (jogadorRoubar != null)
                        {
                            jogador.Roubar(jogadorRoubar);
                            jogador.pilhaPrincipal.Push(cartaDaVez); 
                            Console.WriteLine($"{jogador.Nome} roubou o monte de {jogadorRoubar.Nome}");
                            continue; 
                        }

                        
                        var cartaNaDescarte = areaDescarte.FirstOrDefault(c => c.Numero == cartaDaVez.Numero);
                        if (cartaNaDescarte != null)
                        {
                            jogador.pilhaPrincipal.Push(cartaDaVez); 
                            areaDescarte.Remove(cartaNaDescarte); 
                            Console.WriteLine($"{jogador.Nome} pegou a carta {cartaDaVez.Numero} da área de descarte");
                            continue;
                        }

                        
                        if (jogador.pilhaPrincipal.Count > 0 && jogador.pilhaPrincipal.Peek().Numero == cartaDaVez.Numero)
                        {
                            jogador.pilhaPrincipal.Push(cartaDaVez); 
                            Console.WriteLine($"{jogador.Nome} colocou a carta {cartaDaVez.Numero} no topo do seu monte");
                            continue;
                        }

                        
                        areaDescarte.Add(cartaDaVez);
                        Console.WriteLine($"{jogador.Nome} descartou a carta {cartaDaVez.Numero}");
                    }
                }

                
                Jogador vencedor = jogadors.OrderByDescending(j => j.QuantidadeCartas).First();
                Console.WriteLine($"O vencedor é {vencedor.Nome} com {vencedor.QuantidadeCartas} cartas!");

                
                for (int i = 0; i < jogadors.Count; i++)
                {
                    jogadors[i].AdicionarRanking(i + 1);
                }

                
                Console.WriteLine("Ranking da partida:");
                foreach (var jogador in jogadors.OrderBy(j => j.QuantidadeCartas))
                {
                    Console.WriteLine($"{jogador.Nome} - {jogador.QuantidadeCartas} cartas");
                }

                
                Console.WriteLine("Deseja jogar novamente? (s/n)");
                repete = Console.ReadLine();
            }
        }
    }
}
