using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatanScoreboard.Models
{
    public class FinishedGame
    {
        public FinishedGame()
        {
            PlayerScores = new HashSet<PlayerScore>();
        }
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime GameDateTime { get; set; }
        public string Location { get; set; }
        public ICollection<PlayerScore> PlayerScores { get; set; }
    }
}
