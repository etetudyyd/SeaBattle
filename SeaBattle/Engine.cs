using SeaBattle;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

class Engine
{

    public int size { get; set; }

    public static void Start(List<Statistic> games)
    {
        int size = 15;
        int id = 1;

        char[,] player1field = new char[size, size];
        char[,] player2field = new char[size, size];
        string[] alphabet = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        Console.WriteLine("Enter your name, player 1:");
        string name1 = Console.ReadLine();
        Console.WriteLine("Hello " + name1 + "!");
        Console.WriteLine("Enter your name, player 2:");
        string name2 = Console.ReadLine();
        Console.WriteLine("Hello " + name2 + "!\n");

        GameAccount player1 = new GameAccount(name1, 0, player1field);
        GameAccount player2 = new GameAccount(name2, 0, player2field);


        Stopwatch stopwatch = new Stopwatch();
        Console.WriteLine("1-st player's field");
        stopwatch.Start();  
        fillPlayerField(player1.Battlefield, size, alphabet);
        Console.WriteLine("2-nd player's field");
        fillPlayerField(player2.Battlefield, size, alphabet);

        GameAccount winner = Game.startPlay(player1, player2, size, alphabet);
        stopwatch.Stop();
        long timeduration = stopwatch.ElapsedMilliseconds;
        GameAccount loser = whoIsLoser(winner, player1, player2);

        Game game = new Game(winner, loser, id, timeduration);

        Statistic gamestats = new Statistic(game);
        games.Add(gamestats);
        

    }

    public static void printStatistic(List<Statistic> games) {

        Console.WriteLine(printGames(games));

    }

    public static GameAccount whoIsLoser(GameAccount winner, GameAccount player1, GameAccount player2)
    {

        if (winner == player1)
        {
            return player2;

        }
        else
        {
            return player1;
        }

    }
    public static string printGames(List<Statistic> games)
    {

        var report = new StringBuilder();

        report.AppendLine("    ID  Winner  Loser TimeDuration(sec) ");

        

        foreach (Statistic gamestats in games)
        {
            report.AppendLine($"     {gamestats.Game.ID}\t {gamestats.Game.Winner.Name}\t {gamestats.Game.Loser.Name}\t {gamestats.Game.TimeDuration / 1000} ");
        }

        return report.ToString();
    }





    public static void printField(char[,] battlefield, string[] alphabet)
    {
        Console.WriteLine("\n---------------------------------------------");
        for (int i = 0; i < 11; i++)
        {
            Console.Write("|");
            for (int j = 0; j < 11; j++)
            {
                if (j == 10 && i == 0)
                {
                    Console.Write(" " + j + "|");
                }

                else if (j == 0 && i != 0)
                {

                    Console.Write(" " + alphabet[i - 1] + " |");

                }

                else if (i == 0 && j != 0)
                {
                    Console.Write(" " + j + " |");
                }


                else if (battlefield[i, j] == 0)
                {
                    Console.Write("   |");

                }
                else
                {

                    Console.Write(" " + battlefield[i, j] + " |");

                }
            }

            Console.WriteLine("\n---------------------------------------------");

        }
        Console.WriteLine("");
    }

    public static int validateCoordForShip(char[,] field, int x, int y, int position, int shipType)
    {
        if (x > 10 || x < 1 || y > 10 || y < 1)
        {
            Console.WriteLine("Your cordinates is out of the bounds. Please, enter new cordinates");
            return -1;

        }

        if (position == 1)
        {
            for (int i = 0; i < shipType - 1; i++)
            {
                if ('#' == field[y, x + i]
                || '#' == field[y - 1, x + i]
                || '#' == field[y + 1, x + i]
                || '#' == field[y, x + i + 1]
                || '#' == field[y, x + i - 1]
                || '#' == field[y - 1, x + i - 1]
                || '#' == field[y + 1, x + i - 1]
                || '#' == field[y, x + i - 1]
                || '#' == field[y, x + i - 1]
                || (x + i) > 10)
                {
                    Console.WriteLine("You put ship on another. Please, enter new cordinates");
                    return -1;
                }
            }
        }
        else if (position == 2)
        {

            for (int i = 0; i < shipType - 1; i++)
            {
                if ('#' == field[y, x + i]
                        || '#' == field[y - 1, x + i]
                        || '#' == field[y + 1, x + i]
                        || '#' == field[y, x + i + 1]
                        || '#' == field[y, x + i - 1]
                        || '#' == field[y - 1, x + i - 1]
                        || '#' == field[y + 1, x + i - 1]
                        || '#' == field[y, x + i - 1]
                        || '#' == field[y, x + i - 1]
                        || '#' == field[y, x - 1]
                        || (y + i) > 10)
                {
                    Console.WriteLine("You put ship on another or out the bound of field. Please, enter new cordinates");
                    return -1;
                }
            }
        }
        return 0;
    }

    private static void fillPlayerField(char[,] battlefield, int size, string[] alphabet)
    {

        int q = 0;

        for (int i = 4; i >= 4/*1*/; i--)//розташування кораблів урізано до 1-ого 4-ьох палубного корабля для більшої швидкості тестування
        {                                //програми, уникаючи розташування 10 кораблів для кожного гравця при кожному запуску програми.
                                         //Для оригінальної гри треба зміннити і на 1 у першому циклі, і розкоментувати другий цикл.

            int t = i;

           // for (int k = 1; k <= 5 - i; k++)
          //  {

                Console.WriteLine("Locating " + i + "-size ship. Remains locate " + (5 - t));
                int validationResult = 1;
                while (validationResult != 0)
                {
                    Console.WriteLine("Enter x-cordinate (1 - 10): ");
                    string strx = Console.ReadLine();
                    int x = Convert.ToInt32(strx);
                    Console.WriteLine("Enter y-cordinate (A - J): ");
                    string stry = Console.ReadLine();
                    int y = 0;
                    for (int b = 0; b < alphabet.Length; b++)
                    {
                        if (alphabet[b] == stry)
                        {
                            y = 1 + b;
                            break;
                        }
                    }


                    Console.WriteLine("Enter the position direction:\n 1 - horizontal\n 2 - vertical ");
                    string strposition = Console.ReadLine();
                    int position = Convert.ToInt32(strposition);

                     validationResult = validateCoordForShip(battlefield, x, y, position, i);

                    if (validationResult == -1)
                    {

                    }
                    else
                    {
                        if (position == 1)
                        {
                            for (q = 0; q < i; q++)
                            {
                                battlefield[y, q + x] = '#';
                                battlefield[y - 1, x + q - 1] = 'X';
                                battlefield[y - 1, x + q] = 'X';
                                battlefield[y - 1, x + q + 1] = 'X';
                                battlefield[y + 1, x + q - 1] = 'X';
                                battlefield[y + 1, x + q] = 'X';
                                battlefield[y + 1, x + q + 1] = 'X';
                                if (battlefield[y, x + q - 1] == '#')
                                {
                                }
                                else
                                {
                                    battlefield[y, x + q - 1] = 'X';
                                }
                                if (battlefield[y, x + q + 1] == '#')
                                {
                                }
                                else
                                {
                                    battlefield[y, x + q + 1] = 'X';
                                }
                            }
                        }
                        else if (position == 2)
                        {
                            for (int m = 0; m < i; m++)
                            {
                                battlefield[y + m, x] = '#';
                                battlefield[y + m - 1, x - 1] = 'X';
                                battlefield[y + m, x - 1] = 'X';
                                battlefield[y + m + 1, x - 1] = 'X';
                                battlefield[y + m - 1, x + 1] = 'X';
                                battlefield[y + m, x + 1] = 'X';
                                battlefield[y + m + 1, x + 1] = 'X';
                                if (battlefield[y + m + 1, x] == '#')
                                {
                                }
                                else
                                {
                                    battlefield[y + m + 1, x] = 'X';
                                }
                                if (battlefield[y + m - 1, x] == '#')
                                {
                                }
                                else
                                {
                                    battlefield[y + m - 1, x] = 'X';
                                }
                            }
                        }
                        else
                        {

                            throw new IndexOutOfRangeException(nameof(position));

                        }
                    }
                    printField(battlefield, alphabet);
                    t++;
                }
           // }
        }
    }

}
