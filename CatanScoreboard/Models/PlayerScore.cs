using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanScoreboard.Models
{
    public class PlayerScore
    {
        public int Id { get; set; }
        public int VictoryPoints { get; set; }
        public int Placed { get; set; }
        public int TournamentPoints { get; set; }
        public virtual FinishedGame FinishedGame { get; set; }

        public virtual Player Player { get; set; }
    }
}
