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
            Console.WriteLine($"Vez do jogador {jogadors[i]._Nome}");

            if(cartas.Count == 0 ){
                    break;

                } 

            while (repetei)
            {
                if(cartas.Count == 0 ){
                    break;

                }
                Carta carta = cartas.Pop();
                Console.WriteLine($"jogador {jogadors[i]._Nome} pegou a carta {carta.Numero}");
                for (j = 0; j < index; j++)
                {
                    if (carta.Numero == jogadors[j].pilhaPrincipal.Peek().Numero && jogadors[j].pilhaPrincipal.Count > valorMinimo)
                    {
                        jogador = jogadors[j];
                        eh = true;
                    }
                }
                if (eh && jogador != null)
                {
                    Console.WriteLine($"jogador {jogadors[i]._Nome} roubou todas as {jogador.pilhaPrincipal.Count} de Jogador {jogador._Nome}"); 
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
                else if (carta.Numero == jogadors[i].pilhaPrincipal.Peek().Numero)
                {
                    Console.WriteLine($"jogador {jogadors[i]._Nome} pode jogar mais uma vez");
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











    repete = Console.ReadLine();
}