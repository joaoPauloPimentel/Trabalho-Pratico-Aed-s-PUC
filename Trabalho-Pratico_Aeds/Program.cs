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
while (repete == "s")
{
    for (j = 0; j < cemiterio.Length; j++){
        cemiterio[j] = 0;
    }
    strings.Clear();
    strings.Add("quantos jogadores vão jogar?");
    Console.WriteLine("quantos jogadores vão jogar ?");
    int index = int.Parse(Console.ReadLine());

    List<Jogador> jogadors = new List<Jogador>();

    for (int i = 0; i < index; i++)
    {
        strings.Add($"Jogador {i + 1}, digite seu nome:");
        Console.WriteLine($"Jogador {i + 1}, digite seu nome:");
        jogadors.Add(new Jogador(Console.ReadLine()));
    }
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
            strings.Add($"Vez do jogador {jogadors[i]._Nome}  ");
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
                    strings.Add($"jogador {jogadors[i]._Nome} adiciona a sua primeira carta {carta.Numero} a sua pilha e encerra a jogada ");
                    Console.WriteLine($"jogador {jogadors[i]._Nome} adiciona a sua primeira carta {carta.Numero} a sua pilha e encerra a jogada");
                    repetei = false;
                    eh = false;
                    jogador = null;
                    continue;
                    
                }
                strings.Add($"jogador {jogadors[i]._Nome} pegou a carta {carta.Numero}  ");
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
                    strings.Add($"jogador {jogadors[i]._Nome} roubou todas as {jogador.pilhaPrincipal.Count} cartas de Jogador {jogador._Nome}  ");
                    Console.WriteLine($"jogador {jogadors[i]._Nome} roubou todas as {jogador.pilhaPrincipal.Count} cartas de Jogador {jogador._Nome}"); 
                    jogadors[i].Roubar(jogador);
                    strings.Add($"jogador {jogadors[i]._Nome} pode jogar mais uma vez  ");
                    Console.WriteLine($"jogador {jogadors[i]._Nome} pode jogar mais uma vez");
                }
                else if (cemiterio[carta.Numero - 1] != 0)
                {
                    strings.Add($"jogador {jogadors[i]._Nome} Pegou uma carta do cemiterio ");
                    Console.WriteLine($"jogador {jogadors[i]._Nome} Pegou uma carta do cemiterio");
                    jogadors[i].pilhaPrincipal.Push(carta);
                    jogadors[i].pilhaPrincipal.Push(carta);
                    cemiterio[carta.Numero - 1]--;
                    strings.Add($"jogador {jogadors[i]._Nome} pode jogar mais uma vez  ");
                    Console.WriteLine($"jogador {jogadors[i]._Nome} pode jogar mais uma vez");
                }
                else if (  carta.Numero == jogadors[i].pilhaPrincipal.Peek().Numero)
                {
                    jogadors[i].pilhaPrincipal.Push(carta);
                    strings.Add($"jogador {jogadors[i]._Nome} pode jogar mais uma vez  ");
                    Console.WriteLine($"jogador {jogadors[i]._Nome} pode jogar mais uma vez");
                }
                else
                {
                    strings.Add($"jogador {jogadors[i]._Nome} adicionou a carta {carta.Numero} ao cemiterio e perdeu a vez  ");
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
                strings.Add($"O vencedor é {vencedor._Nome} com {vencedor.pilhaPrincipal.Count} cartas! \n ");
                Console.WriteLine($"O vencedor é {vencedor._Nome} com {vencedor.pilhaPrincipal.Count} cartas!");

                
                for (int i = 0; i < jogadors.Count; i++)
                {
                    jogadors[i].AdicionarRanking(i + 1);
                }

                
                Console.WriteLine("Ranking da partida:");
                foreach (var jogador1 in jogadors.OrderBy(j => j.pilhaPrincipal.Count))
                {
                    strings.Add($"{jogador1._Nome} - {jogador1.pilhaPrincipal.Count} cartas \n");

                    Console.WriteLine($"{jogador1._Nome} - {jogador1.pilhaPrincipal.Count} cartas");
                }

                strings.Add("Deseja jogar novamente? (s/n) \n");
                Console.WriteLine("Deseja jogar novamente? (s/n)");
                repete = Console.ReadLine();
                LogdoJogo =  string.Concat(LogdoJogo,repete);
                
}
StreamWriter arq = new StreamWriter("LogTemp.txt");
foreach(string line in strings){
    arq.WriteLine(line);

}
arq.Close();