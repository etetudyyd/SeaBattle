using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Program
    {
        public static void Main(String[] args)  {

            List<Statistic> games = new List<Statistic>();
            bool isPlaying = true;
            while (isPlaying) {
                Console.WriteLine(" 1. Play");
                Console.WriteLine(" 2. Statistic");
                Console.WriteLine(" 3. Exit");

                string strnum = Console.ReadLine();
                int num = Convert.ToInt32(strnum);

                switch (num) {
                    case 1:
                        Engine.Start(games);
                        break;

                    case 2:
                        if (games == null) {
                            Console.WriteLine("List is empty!");
                        }
                        else {
                            Engine.printStatistic(games);
                        }
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
