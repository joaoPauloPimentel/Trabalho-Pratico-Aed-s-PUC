using Trabalho_Pratico_Aeds;
int valorMinimo = 0;

bool eh = false;
int j;
Jogador jogador = null;
int[] cimiterio = new int[12];
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
            if(cartas.Count == 0 ){
                    break;

                } 

            while (repetei)
            {
                if(cartas.Count == 0 ){
                    break;

                }
                Carta carta = cartas.Pop();
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
                    jogadors[i].Roubar(jogador);
                }
                else if (cimiterio[carta.Numero - 1] != 0)
                {
                    jogadors[i].pilhaPrincipal.Push(carta);
                    jogadors[i].pilhaPrincipal.Push(carta);
                    cimiterio[carta.Numero - 1]--;
                }
                else if (carta.Numero == jogadors[i].pilhaPrincipal.Peek().Numero)
                {
                    jogadors[i].pilhaPrincipal.Push(carta);
                }
                else
                {
                    cimiterio[carta.Numero - 1]++;
                    repetei = false;
                }
                eh = false;
                jogador = null;

            }



        }
    }











    repete = Console.ReadLine();
}