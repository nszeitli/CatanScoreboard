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
        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Date of game")]
        public DateTime GameDateTime { get; set; }
        [Display(Name = "Location where played")]
        [Required]
        public string Location { get; set; }
        [Display(Name = "Player1 Name")]
        [Required]
        public int Player1Name { get; set; }
        [Display(Name = "Player1 Score")]
        [Required]
        public int Player1Score { get; set; }
        [Display(Name = "Player2 Name")]
        [Required]
        public int Player2Name { get; set; }
        [Display(Name = "Player2 Score")]
        [Required]
        public int Player2Score { get; set; }
        [Display(Name = "Player3 Name")]
        [Required]
        public int Player3Name { get; set; }
        [Display(Name = "Player3 Score")]
        [Required]
        public int Player3Score { get; set; }
        [Display(Name = "Player4 Name")]
        [Required]
        public int Player4Name { get; set; }
        [Display(Name = "Player4 Score")]
        [Required]
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
