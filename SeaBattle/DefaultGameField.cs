using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class DefaultGameField
    {
        public int FieldId { get; set; }
        public int Size { get; set; }
        public char[,] Battlefield { get; set; }

        public string[] alphabet = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        public DefaultGameField(int fieldid, int size)
        {
            FieldId = fieldid;
            Size = size;
            Battlefield = new char[Size, Size];

        }

        public int validateCoordForShip(int x, int y, int position, int shipType)
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
                    if ('#' == Battlefield[y, x + i]
                    || '#' == Battlefield[y - 1, x + i]
                    || '#' == Battlefield[y + 1, x + i]
                    || '#' == Battlefield[y, x + i + 1]
                    || '#' == Battlefield[y, x + i - 1]
                    || '#' == Battlefield[y - 1, x + i - 1]
                    || '#' == Battlefield[y + 1, x + i - 1]
                    || '#' == Battlefield[y, x + i - 1]
                    || '#' == Battlefield[y, x + i - 1]
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
                    if ('#' == Battlefield[y, x + i]
                            || '#' == Battlefield[y - 1, x + i]
                            || '#' == Battlefield[y + 1, x + i]
                            || '#' == Battlefield[y, x + i + 1]
                            || '#' == Battlefield[y, x + i - 1]
                            || '#' == Battlefield[y - 1, x + i - 1]
                            || '#' == Battlefield[y + 1, x + i - 1]
                            || '#' == Battlefield[y, x + i - 1]
                            || '#' == Battlefield[y, x + i - 1]
                            || '#' == Battlefield[y, x - 1]
                            || (y + i) > 10)
                    {
                        Console.WriteLine("You put ship on another or out the bound of field. Please, enter new cordinates");
                        return -1;
                    }
                }
            }
            return 0;
        }


        public virtual void fillField()
        {

            int q = 0;

            Console.WriteLine("Enter " + FieldId + "-st field");

            for (int i = 4; i >= 1; i--)
            {

                int t = i;

                for (int k = 1; k <= 5 - i; k++)
                {

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

                        validationResult = validateCoordForShip(x, y, position, i);



                        if (validationResult == -1)
                        {

                        }
                        else
                        {
                            if (position == 1)
                            {
                                for (q = 0; q < i; q++)
                                {
                                    Battlefield[y, q + x] = '#';
                                    Battlefield[y - 1, x + q - 1] = 'X';
                                    Battlefield[y - 1, x + q] = 'X';
                                    Battlefield[y - 1, x + q + 1] = 'X';
                                    Battlefield[y + 1, x + q - 1] = 'X';
                                    Battlefield[y + 1, x + q] = 'X';
                                    Battlefield[y + 1, x + q + 1] = 'X';
                                    if (Battlefield[y, x + q - 1] == '#')
                                    {
                                    }
                                    else
                                    {
                                        Battlefield[y, x + q - 1] = 'X';
                                    }
                                    if (Battlefield[y, x + q + 1] == '#')
                                    {
                                    }
                                    else
                                    {
                                        Battlefield[y, x + q + 1] = 'X';
                                    }
                                }
                            }
                            else if (position == 2)
                            {
                                for (int m = 0; m < i; m++)
                                {
                                    Battlefield[y + m, x] = '#';
                                    Battlefield[y + m - 1, x - 1] = 'X';
                                    Battlefield[y + m, x - 1] = 'X';
                                    Battlefield[y + m + 1, x - 1] = 'X';
                                    Battlefield[y + m - 1, x + 1] = 'X';
                                    Battlefield[y + m, x + 1] = 'X';
                                    Battlefield[y + m + 1, x + 1] = 'X';
                                    if (Battlefield[y + m + 1, x] == '#')
                                    {
                                    }
                                    else
                                    {
                                        Battlefield[y + m + 1, x] = 'X';
                                    }
                                    if (Battlefield[y + m - 1, x] == '#')
                                    {
                                    }
                                    else
                                    {
                                        Battlefield[y + m - 1, x] = 'X';
                                    }
                                }
                            }
                            else
                            {

                                throw new IndexOutOfRangeException(nameof(position));

                            }
                        }

                        t++;
                    }
                }
            }
        }


        public void printField()
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


                    else if (Battlefield[i, j] == 0)
                    {
                        Console.Write("   |");

                    }
                    else
                    {

                        Console.Write(" " + Battlefield[i, j] + " |");

                    }
                }

                Console.WriteLine("\n---------------------------------------------");

            }
            Console.WriteLine("");
        }

        public static void printField(char[,] Battlefield, string[] alphabet)//Цей метод залишився статичним, бо якщо його робити нестатичним, код дуже перегружається із-за того, що прийдеться додатково створювати в GameAccount ще один вид поля тільки для виводу його на екран.
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


                    else if (Battlefield[i, j] == 0)
                    {
                        Console.Write("   |");

                    }
                    else
                    {

                        Console.Write(" " + Battlefield[i, j] + " |");

                    }
                }

                Console.WriteLine("\n---------------------------------------------");

            }
            Console.WriteLine("");
        }


    }
}