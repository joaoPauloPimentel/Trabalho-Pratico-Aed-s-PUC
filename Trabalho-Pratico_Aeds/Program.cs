using Trabalho_Pratico_Aeds;
int valorMinimo = 0;
bool eh = false;
int j;
Jogador jogador = null;
int[] cemiterio = new int[12];
bool repetei = true;
Random random = new Random();
string repete = "s";
while (repete == "s")
{
    Console.WriteLine("quantos jogadores vão jogar ?");
    int index = int.Parse(Console.ReadLine());

    List<Jogador> jogadors = new List<Jogador>();

    for (int i = 0; i < index; i++)
    {
        Console.WriteLine($"Jogador {i + 1}, digite seu nome:");
        jogadors.Add(new Jogador(Console.ReadLine()));
    }
    Console.WriteLine("Quantas cartas terá no monte ?");
    int quantCartas = int.Parse(Console.ReadLine());
    Stack<Carta> cartas = new Stack<Carta>();
    for (int i = 0; i < quantCartas; i++)
    {
        cartas.Push(new Carta(random.Next(1, 13)));
    }
    while (cartas.Count > 0)
    {
        for (int i = 0; i < index; i++)
        {
            System.Console.WriteLine($"Vez do jogador {jogadors[i]._Nome}");
            if(cartas.Count == 0 ){
                    break;
                } 
            repetei = true;
            while (repetei)
            {
                if(cartas.Count == 0 ){
                    break;

                }
                Carta carta = cartas.Pop();
                if(jogadors[i].pilhaPrincipal.Count == 0){
                    jogadors[i].pilhaPrincipal.Push(carta);
                    Console.WriteLine($"jogador {jogadors[i]._Nome} adiciona a sua primeira carta {carta.Numero} a sua pilha e encerra a jogada");
                    repetei = false;
                    eh = false;
                    jogador = null;
                    continue;
                    
                }
                Console.WriteLine($"jogador {jogadors[i]._Nome} pegou a carta {carta.Numero}");
                for (j = 0; j < index; j++)
                {
                    
                    if ( jogadors[j].pilhaPrincipal.Count != 0 && carta.Numero == jogadors[j].pilhaPrincipal.Peek().Numero  && jogadors[j].pilhaPrincipal.Count > valorMinimo && jogadors[j]._Nome != jogadors[i]._Nome )
                    {
                        jogador = jogadors[j];
                        eh = true;
                    }
                }
                if (eh && jogador != null)
                {
                    Console.WriteLine($"jogador {jogadors[i]._Nome} roubou todas as {jogador.pilhaPrincipal.Count} cartas de Jogador {jogador._Nome}"); 
                    jogadors[i].Roubar(jogador);
                    Console.WriteLine($"jogador {jogadors[i]._Nome} pode jogar mais uma vez");
                }
                else if (cemiterio[carta.Numero - 1] != 0)
                {
                    Console.WriteLine($"jogador {jogadors[i]._Nome} Pegou uma carta do cemiterio");
                    jogadors[i].pilhaPrincipal.Push(carta);
                    jogadors[i].pilhaPrincipal.Push(carta);
                    cemiterio[carta.Numero - 1]--;
                    Console.WriteLine($"jogador {jogadors[i]._Nome} pode jogar mais uma vez");
                }
                else if (  carta.Numero == jogadors[i].pilhaPrincipal.Peek().Numero)
                {
                    jogadors[i].pilhaPrincipal.Push(carta);
                    Console.WriteLine($"jogador {jogadors[i]._Nome} pode jogar mais uma vez");
                }
                else
                {
                    Console.WriteLine($"jogador {jogadors[i]._Nome} adicionou a carta {carta.Numero} ao cemiterio e perdeu a vez");
                    cemiterio[carta.Numero - 1]++;
                    repetei = false;
                }
                eh = false;
                jogador = null;
            }
        }
    }


                Jogador vencedor = jogadors.OrderByDescending(j => j.pilhaPrincipal.Count).First();
                Console.WriteLine($"O vencedor é {vencedor._Nome} com {vencedor.pilhaPrincipal.Count} cartas!");

                
                for (int i = 0; i < jogadors.Count; i++)
                {
                    jogadors[i].AdicionarRanking(i + 1);
                }

                
                Console.WriteLine("Ranking da partida:");
                foreach (var jogador1 in jogadors.OrderBy(j => j.pilhaPrincipal.Count))
                {
                    Console.WriteLine($"{jogador1._Nome} - {jogador1.pilhaPrincipal.Count} cartas");
                }

                
                Console.WriteLine("Deseja jogar novamente? (s/n)");
                repete = Console.ReadLine();
}