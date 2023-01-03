using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Game
    {

        public GameAccount startPlay(GameAccount player1, GameAccount player2)
        {

            char[,] playerBattleField1 = new char[player1.Field.Size, player1.Field.Size];
            char[,] playerBattleField2 = new char[player2.Field.Size, player2.Field.Size];

            GameAccount currentPlayer = player1;

            char[,] currentPlayerField = player2.Field.Battlefield;

            char[,] currentPlayerBattleField = playerBattleField1;


            while (isPlayerAlive(player1.Field.Battlefield, player1.Field.Size) && isPlayerAlive(player2.Field.Battlefield, player2.Field.Size))
            {
                DefaultGameField.printField(currentPlayerBattleField, player1.Field.alphabet);

                Console.WriteLine(currentPlayer.Name + " your turn, please, input x coord of shot");
                string strxshoot = Console.ReadLine();
                int xshoot = Convert.ToInt32(strxshoot);
                Console.WriteLine(currentPlayer.Name + " your turn, please, input y coord of shot");
                string stryshoot = Console.ReadLine();

                int yshoot = 0;

                for (int b = 0; b < player1.Field.alphabet.Length; b++)
                {
                    if (player1.Field.alphabet[b] == stryshoot)
                    {
                        yshoot = 1 + b;
                        break;
                    }
                }

                int shotResult = handleShot(currentPlayerBattleField, currentPlayerField, xshoot, yshoot);

                if (shotResult == 0 && currentPlayer.Name == player1.Name)
                {
                    currentPlayer = player2;
                    currentPlayerField = player1.Field.Battlefield;
                    currentPlayerBattleField = playerBattleField2;
                }

                else if (shotResult == 0 && currentPlayer.Name == player2.Name)
                {
                    currentPlayer = player1;
                    currentPlayerField = player2.Field.Battlefield;
                    currentPlayerBattleField = playerBattleField1;
                }
            }

            Console.WriteLine(currentPlayer.Name + " is Winner!");
            player1.AmountofGames++;
            player2.AmountofGames++;
            if (currentPlayer == player1)
            {
                return player1;
            }
            else
            {
                return player2;
            }
        }

        private int handleShot(char[,] battleField, char[,] field, int x, int y)
        {
            if (x > 10 || x < 1 || y > 10 || y < 1)
            {
                Console.WriteLine("Your cordinates is out of the bounds. Please, enter new cordinates");
                return -1;

            }

            if ('#' == field[y, x])
            {
                if (field[y - 1, x] == '#'
                || field[y + 1, x] == '#'
                || field[y, x + 1] == '#'
                || field[y, x - 1] == '#')
                {
                    field[y, x] = 'X';
                    battleField[y, x] = 'X';
                    Console.WriteLine("Good shot! Wounded!");


                }
                else
                {
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
            battleField[y, x] = '*';
            Console.WriteLine("Bad shot!");

            return 0;
        }

        private bool isPlayerAlive(char[,] field, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ('#' == field[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}