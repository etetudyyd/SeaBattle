using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Statistic
    {
        public GameAccount Winner { get; set; }
        public GameAccount Loser { get; set; }
        public int ID { get; set; }
        public long TimeDuration { get; set; }

         public Statistic(GameAccount winner, GameAccount loser, int id, long timeDuration)
        {

            Winner = winner;
            Loser = loser;
            ID = id;
            TimeDuration = timeDuration; 
        }
    }
}