using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatanScoreboard.Models;
using CatanScoreboard.Data;

namespace CatanScoreboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allPlayers = _context.Players.ToList();
            
            LeaderViewModel vm = new LeaderViewModel();
            vm.Players = new List<PlayerViewModel>();

            Dictionary<int, int> placings = new Dictionary<int, int>();
            foreach (var item in allPlayers)
            {
                PlayerViewModel p = new PlayerViewModel();
                //Get scores
                var scores = _context.PlayerScores.Where(j => j.Player.Id == item.Id).ToList();
                
                p.Id = item.Id;
                var s = _context.FinishedGames.ToList();
                p.Name = item.Name;
                p.TournamentPoints = scores.Sum(j => j.TournamentPoints);
                p.Wins = scores.Count(j => j.Placed == 1);
                p.Games = scores.Count();
                if(p.Games == 0 || p.TournamentPoints == 0) { p.AvgPoints = 0; } else { p.AvgPoints = p.TournamentPoints / p.Games; }

                vm.Players.Add(p);
            }
            vm.Players = vm.Players.OrderByDescending(j => j.TournamentPoints).ToList();
            int i = 1;
            
            foreach (var item in vm.Players)
            {
                item.CurrentRank = i;
                i++;
            }


            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
