using SeaBattle;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml.Linq;


class Engine
{

    public List<Statistic> statistics { get; set; }

    public Engine() {
    
        statistics = new List<Statistic>();
    }

    public void Start(int gamecount,int game)
    {
        DefaultGameField field1;
        DefaultGameField field2;

        Console.WriteLine("Enter your name, player 1:");
        string name1 = Console.ReadLine();
        Console.WriteLine("Hello " + name1 + "!");
        Console.WriteLine("Enter your name, player 2:");
        string name2 = Console.ReadLine();
        Console.WriteLine("Hello " + name2 + "!\n");


        if (game == 1)
        {
            field1 = new QuickGameField(1, 15);

            field2 = new QuickGameField(2, 15);
        }

        else
        {
            field1 = new DefaultGameField(1, 15);

            field2 = new DefaultGameField(2, 15);
        }

       
        field1.fillField();

        field1.printField();

        field2.fillField();

        field2.printField();

        GameAccount player1 = new GameAccount(name1, 0, field1);
        GameAccount player2 = new GameAccount(name2, 0, field2);

        Stopwatch stopwatch = new Stopwatch();
 
        Game gameplay = new Game();
        stopwatch.Start();
        GameAccount winner = gameplay.startPlay(player1, player2);
        stopwatch.Stop();
        long timeduration = stopwatch.ElapsedMilliseconds;

        GameAccount loser;

        if (player1 == winner)
        {
            loser = player2;
        }
        else
        {
            loser = player1;
        }

        Statistic gamestats = new Statistic(winner, loser, gamecount, timeduration);

        statistics.Add(gamestats);
    }
    public void printStatistic()
    {

        Console.WriteLine(printGames());

    }
    public string printGames()
    {

        var report = new StringBuilder();

        report.AppendLine("    ID  Winner  Loser TimeDuration(sec) ");


        foreach (Statistic gamestats in statistics)
        {
            report.AppendLine($"     {gamestats.ID}\t {gamestats.Winner.Name}\t {gamestats.Loser.Name}\t {gamestats.TimeDuration / 1000} ");
        }

        return report.ToString();
    }
}
