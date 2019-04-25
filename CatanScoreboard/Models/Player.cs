using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanScoreboard.Models
{
    public class Player
    {
        public Player()
        {
            ScoreHistory = new HashSet<PlayerScore>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<PlayerScore> ScoreHistory { get; set; }
    }
}
