using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanScoreboard.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int CurrentRank { get; set; }
        public int TournamentPoints { get; set; }
        public int Wins { get; set; }
        public int Games { get; set; }
        public double AvgPoints { get; set; }
    }
}
