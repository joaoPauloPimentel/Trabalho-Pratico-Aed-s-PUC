using Trabalho_Pratico_Aeds;
public class Jogador
{
    private int Posicao { get; set; }
    private string nome;
    public Queue<int> HistoricoPosicoes { get; } = new Queue<int>(5);
    public string _Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public Stack<Carta> pilhaPrincipal = new Stack<Carta>();

    public Jogador(string nome)
    {
        this.nome = nome;
    }

    public void Roubar(Jogador jogador)
    {
        while (jogador.pilhaPrincipal.Count > 0)
        {
            Carta carta = jogador.pilhaPrincipal.Pop();
            pilhaPrincipal.Push(carta);
        }
    }

    public void AdicionarRanking(int posicao)
    {
        System.Console.WriteLine(HistoricoPosicoes.Count == 5);
        if (HistoricoPosicoes.Count == 5)
        {
            HistoricoPosicoes.Dequeue();
        }
        HistoricoPosicoes.Enqueue(posicao);
    }
}