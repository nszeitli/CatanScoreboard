using CatanScoreboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanScoreboard.Helpers
{
    public class TournamentHelper
    {
        public List<PlayerScore> GetPlacingsAndPoints(List<PlayerScore> list)
        {
            List<PlayerScore> output = new List<PlayerScore>();

            Dictionary<int, int> placings = GetPlacings(list);
            foreach (var item in list)
            {
                if(item.Player != null)
                {
                    item.Placed = placings[item.Player.Id];
                    item.TournamentPoints = GetTournamentPoints(item.VictoryPoints, item.Placed);
                    output.Add(item);
                }
            }
            return output;
        }
        public Dictionary<int, int> GetPlacings(List<PlayerScore> scores)
        {
            Dictionary<int, int> output = new Dictionary<int, int>();

            var list = scores.OrderByDescending(x => x.VictoryPoints).ToList();

            int i = 1;
            foreach (var item in list)
            {
                output.Add(item.Player.Id, i);
                i++;
            }
            return output;
        }

        public int GetTournamentPoints(int score, int placing)
        {
            int output = score;
            if (placing == 1)
            {
                score = score + 1;
            }

            return score;
        }
    }

}
