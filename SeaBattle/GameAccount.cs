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
        public DefaultGameField Field { get; set; }
        public bool IsLoser { get; set; }

        public GameAccount(string name, int amountofgames, DefaultGameField field)
        {
            Name = name;
            AmountofGames = amountofgames;
            Field = field;
            IsLoser = true;
        }

    }
}
