using Microsoft.VisualBasic;
using Trabalho_Pratico_Aeds;
int valorMinimo = 0;
bool eh = false;
int j;
Jogador jogador = null;
string LogdoJogo = "";
int[] cemiterio = new int[12];
bool repetei = true;
Random random = new Random();
List<string> strings = new List<string>();
string repete = "s";
strings.Add("quantos jogadores vão jogar?");
    Console.WriteLine("quantos jogadores vão jogar ?");
    int index = int.Parse(Console.ReadLine());

    List<Jogador> jogadores = new List<Jogador>();

    for (int i = 0; i < index; i++)
    {
        strings.Add($"Jogador {i + 1}, digite seu nome:");
        Console.WriteLine($"Jogador {i + 1}, digite seu nome:");
        jogadores.Add(new Jogador(Console.ReadLine()));
    }
while (repete == "s")
{
    foreach(Jogador atual in jogadores){
        atual.pilhaPrincipal.Clear();
    }
    for (j = 0; j < cemiterio.Length; j++)
    {
        cemiterio[j] = 0;
    }
    strings.Clear();
    
    strings.Add("Quantas cartas terá no monte ?");
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
            strings.Add($"Vez do jogador {jogadores[i]._Nome}  ");
            System.Console.WriteLine($"Vez do jogador {jogadores[i]._Nome}");
            if (cartas.Count == 0)
            {
                break;
            }
            repetei = true;
            while (repetei)
            {
                if (cartas.Count == 0)
                {
                    break;

                }
                Carta carta = cartas.Pop();
                if (jogadores[i].pilhaPrincipal.Count == 0)
                {
                    jogadores[i].pilhaPrincipal.Push(carta);
                    strings.Add($"jogador {jogadores[i]._Nome} adiciona a sua primeira carta {carta.Numero} a sua pilha e encerra a jogada ");
                    Console.WriteLine($"jogador {jogadores[i]._Nome} adiciona a sua primeira carta {carta.Numero} a sua pilha e encerra a jogada");
                    repetei = false;
                    eh = false;
                    jogador = null;
                    continue;

                }
                strings.Add($"jogador {jogadores[i]._Nome} pegou a carta {carta.Numero}  ");
                Console.WriteLine($"jogador {jogadores[i]._Nome} pegou a carta {carta.Numero}");
                for (j = 0; j < index; j++)
                {

                    if (jogadores[j].pilhaPrincipal.Count != 0 && carta.Numero == jogadores[j].pilhaPrincipal.Peek().Numero && jogadores[j].pilhaPrincipal.Count > valorMinimo && jogadores[j]._Nome != jogadores[i]._Nome)
                    {
                        jogador = jogadores[j];
                        eh = true;
                    }
                }
                if (eh && jogador != null)
                {
                    strings.Add($"jogador {jogadores[i]._Nome} roubou todas as {jogador.pilhaPrincipal.Count} cartas de Jogador {jogador._Nome}  ");
                    Console.WriteLine($"jogador {jogadores[i]._Nome} roubou todas as {jogador.pilhaPrincipal.Count} cartas de Jogador {jogador._Nome}");
                    jogadores[i].Roubar(jogador);
                    strings.Add($"jogador {jogadores[i]._Nome} pode jogar mais uma vez  ");
                    Console.WriteLine($"jogador {jogadores[i]._Nome} pode jogar mais uma vez");
                }
                else if (cemiterio[carta.Numero - 1] != 0)
                {
                    strings.Add($"jogador {jogadores[i]._Nome} Pegou uma carta do cemiterio ");
                    Console.WriteLine($"jogador {jogadores[i]._Nome} Pegou uma carta do cemiterio");
                    jogadores[i].pilhaPrincipal.Push(carta);
                    jogadores[i].pilhaPrincipal.Push(carta);
                    cemiterio[carta.Numero - 1]--;
                    strings.Add($"jogador {jogadores[i]._Nome} pode jogar mais uma vez  ");
                    Console.WriteLine($"jogador {jogadores[i]._Nome} pode jogar mais uma vez");
                }
                else if (carta.Numero == jogadores[i].pilhaPrincipal.Peek().Numero)
                {
                    jogadores[i].pilhaPrincipal.Push(carta);
                    strings.Add($"jogador {jogadores[i]._Nome} pode jogar mais uma vez  ");
                    Console.WriteLine($"jogador {jogadores[i]._Nome} pode jogar mais uma vez");
                }
                else
                {
                    strings.Add($"jogador {jogadores[i]._Nome} adicionou a carta {carta.Numero} ao cemiterio e perdeu a vez  ");
                    Console.WriteLine($"jogador {jogadores[i]._Nome} adicionou a carta {carta.Numero} ao cemiterio e perdeu a vez");
                    cemiterio[carta.Numero - 1]++;
                    repetei = false;
                }
                eh = false;
                jogador = null;
            }
        }
    }


    Jogador vencedor = jogadores.OrderByDescending(j => j.pilhaPrincipal.Count).First();
    strings.Add($"O vencedor é {vencedor._Nome} com {vencedor.pilhaPrincipal.Count} cartas! \n ");
    Console.WriteLine($"O vencedor é {vencedor._Nome} com {vencedor.pilhaPrincipal.Count} cartas!");

    for (int i = 0; i < jogadores.Count; i++)
    {
        if (jogadores[i].pilhaPrincipal.Count > 0)
        {
            jogadores[i].AdicionarRanking(i + 1);
        }
        else
        {
            jogadores[i].AdicionarRanking(0);
        }
    }

    Console.WriteLine("Ranking da partida:");
    foreach (var jogador1 in jogadores.OrderBy(j => j.pilhaPrincipal.Count))
    {
        strings.Add($"{jogador1._Nome} - {jogador1.pilhaPrincipal.Count} cartas \n");
        Console.WriteLine($"{jogador1._Nome} - {jogador1.pilhaPrincipal.Count} cartas");
    }

    Console.WriteLine("Deseja ver o histórico de posições de algum jogador? (s/n)");
    string visualizarHistorico = Console.ReadLine().ToLower();

    if (visualizarHistorico == "s")
    {
        Console.WriteLine("Digite o nome do jogador:");
        string nomeJogador = Console.ReadLine();

        Jogador jogadorSelecionado = jogadores.FirstOrDefault(j => j._Nome.Equals(nomeJogador, StringComparison.OrdinalIgnoreCase));

        if (jogadorSelecionado != null)
        {
            Console.WriteLine($"Histórico de posições de {jogadorSelecionado._Nome}:");

            foreach (var posicao in jogadorSelecionado.HistoricoPosicoes)
            {
                Console.WriteLine($"Posição: {posicao}");
            }
        }
        else
        {
            Console.WriteLine($"Jogador {nomeJogador} não encontrado.");
        }
    }

    strings.Add("Deseja jogar novamente? (s/n) \n");
    Console.WriteLine("Deseja jogar novamente? (s/n)");
    repete = Console.ReadLine();
    LogdoJogo = string.Concat(LogdoJogo, repete);

}
StreamWriter arq = new StreamWriter("LogTemp.txt");
foreach (string line in strings)
{
    arq.WriteLine(line);

}
arq.Close();