using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class QuickGameField : DefaultGameField
    {
        public QuickGameField(int fieldid, int size) 
            : base(fieldid, size)
        {

        }

        public override void fillField()
        {

            int q = 0;

            Console.WriteLine("Enter " + FieldId + "-st field");

            for (int i = 4; i >= 4; i--)
            {

                int t = i;


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
}
