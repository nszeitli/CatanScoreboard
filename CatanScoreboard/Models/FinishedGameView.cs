using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatanScoreboard.Models
{
    public class FinishedGameView
    {
        public FinishedGameView()
        {
            PlayerList = new List<PlayerViewModel>();
        }
        public List<PlayerViewModel> PlayerList { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of game")]
        public DateTime GameDateTime { get; set; }
        [Display(Name = "Location where played")]
        public string Location { get; set; }
        [Display(Name = "Player1 Name")]
        public int Player1Name { get; set; }
        [Display(Name = "Player1 Score")]
        public int Player1Score { get; set; }
        [Display(Name = "Player2 Name")]
        public int Player2Name { get; set; }
        [Display(Name = "Player2 Score")]
        public int Player2Score { get; set; }
        [Display(Name = "Player3 Name")]
        public int Player3Name { get; set; }
        [Display(Name = "Player3 Score")]
        public int Player3Score { get; set; }
        [Display(Name = "Player4 Name")]
        public int Player4Name { get; set; }
        [Display(Name = "Player4 Score")]
        public int Player4Score { get; set; }
        [Display(Name = "Player5 Name")]
        public int Player5Name { get; set; }
        [Display(Name = "Player5 Score")]
        public int Player5Score { get; set; }
        [Display(Name = "Player6 Name")]
        public int Player6Name { get; set; }
        [Display(Name = "Player6 Score")]
        public int Player6Score { get; set; }
    }
}
