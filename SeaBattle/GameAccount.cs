using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class GameAccount
    {
        public string Name { get; set; }
        public int AmountofGames { get; set; }
        public char[,] Battlefield { get; set; }


        public GameAccount(string name, int amountofgames, char[,] battlefield)
        {
            Name = name;
            AmountofGames = amountofgames;
            Battlefield = battlefield;
        }
    }
}
