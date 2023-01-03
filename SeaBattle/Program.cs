using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeaBattle
{
    public class Program
    {
        public static void Main(String[] args)
        {
            int gamecount = 1;
            bool isPlaying = true;
            Engine engine = new Engine();

            while (isPlaying)
            {
                Console.WriteLine(" 1. Play");
                Console.WriteLine(" 2. Statistic");
                Console.WriteLine(" 3. Exit");

                string strnum = Console.ReadLine();
                int num = Convert.ToInt32(strnum);

                

                switch (num)
                {
                    case 1:
                        Console.WriteLine(" 1. QuickGame\n" +
                            "2. DefaultGame");

                        string strgame = Console.ReadLine();
                        int game = Convert.ToInt32(strgame);

                            engine.Start(gamecount, game);
                            gamecount++;
    
                        break;

                    case 2:

                        engine.printStatistic();
                        
                        break;

                    case 3:
                        isPlaying = false;
                        break;
                    default:
                        break;
                }

            }

        }
    }
}
