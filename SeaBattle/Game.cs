using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Game {

        public GameAccount Winner { get; set; }
        public GameAccount Loser { get; set; }
        public int ID { get; set; }

        public long TimeDuration { get; set; }   

        public Game(GameAccount winner, GameAccount loser, int id, long timeDuration)
        {

            Winner = winner;
            Loser = loser;
            ID = id;
            TimeDuration = timeDuration;
        }



        public static GameAccount startPlay(GameAccount player1, GameAccount player2, int size, string[] alphabet)
        {

            char[,] playerBattleField1 = new char[size,size];
            char[,] playerBattleField2 = new char[size,size];

            string currentPlayerName = player1.Name;
            char[,] currentPlayerField = player2.Battlefield;
            char[,] currentPlayerBattleField = playerBattleField1;

            
           while (isPlayerAlive(player1.Battlefield, size) && isPlayerAlive(player2.Battlefield, size))
            {
                Engine.printField(currentPlayerBattleField, alphabet);
                
                Console.WriteLine(currentPlayerName + " your turn, please, input x coord of shot");
                string strxshoot = Console.ReadLine();
                int xshoot = Convert.ToInt32(strxshoot);
                Console.WriteLine(currentPlayerName + " your turn, please, input y coord of shot");
                string stryshoot = Console.ReadLine();

                int yshoot = 0;

                for (int b = 0; b < alphabet.Length; b++)
                {
                    if (alphabet[b] == stryshoot)
                    {
                        yshoot = 1 + b;
                        break;
                    }
                }

                int shotResult = handleShot(currentPlayerBattleField, currentPlayerField, xshoot, yshoot);

                if (shotResult == 0 && currentPlayerName == player1.Name)
                {
                    currentPlayerName = player2.Name;
                    currentPlayerField = player1.Battlefield;
                    currentPlayerBattleField = playerBattleField2;
                }

               else if (shotResult == 0 && currentPlayerName == player2.Name)
                {
                    currentPlayerName = player1.Name;
                    currentPlayerField = player2.Battlefield;
                    currentPlayerBattleField = playerBattleField1;
                }
            }

            Console.WriteLine(currentPlayerName + " is Winner!");
            player1.AmountofGames++;
            player2.AmountofGames++;
            if (currentPlayerName == player1.Name)
            {
                return player1;
            }
            else {
                return player2;
            }          
        }

        private static int handleShot(char[,] battleField, char[,] field, int x, int y)
        {
            if (x > 10 || x < 1 || y > 10 || y < 1)
            {
                Console.WriteLine("Your cordinates is out of the bounds. Please, enter new cordinates");
                return -1;

            }

            if ('#' == field[y,x])
            {
                if (field[y - 1, x] == '#'
                || field[y + 1, x] == '#'
                || field[y, x + 1] == '#'
                || field[y, x - 1] == '#') {
                    field[y, x] = 'X';
                    battleField[y, x] = 'X';
                    Console.WriteLine("Good shot! Wounded!");
                   

                }
                else {
                    field[y, x] = 'X';
                    battleField[y, x] = 'X';
                    Console.WriteLine("Good shot! Killed!");
                }
                battleField[y - 1, x - 1] = '*';
                battleField[y - 1, x + 1] = '*';
                battleField[y + 1, x - 1] = '*';
                battleField[y + 1, x + 1] = '*';
                return 1;
            }
            battleField[y,x] = '*';
            Console.WriteLine("Bad shot!");

            return 0;
        }

        private static bool isPlayerAlive(char[,] field, int size)
        {
            for (int i = 0;i < size;i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ('#' == field[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
