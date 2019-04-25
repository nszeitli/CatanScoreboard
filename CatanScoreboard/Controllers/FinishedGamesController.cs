using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatanScoreboard.Data;
using CatanScoreboard.Models;

namespace CatanScoreboard.Controllers
{
    public class FinishedGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinishedGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FinishedGames
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinishedGames.ToListAsync());
        }

        // GET: FinishedGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finishedGame = await _context.FinishedGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finishedGame == null)
            {
                return NotFound();
            }

            return View(finishedGame);
        }

        // GET: FinishedGames/Create
        public IActionResult Create()
        {
            FinishedGameView finishedGameVM = new FinishedGameView();
            var players =  _context.Players.ToList();
            List<PlayerViewModel> vmList = new List<PlayerViewModel>();
            finishedGameVM.GameDateTime = DateTime.Today;
            finishedGameVM.GameDateTime = finishedGameVM.GameDateTime.AddHours(DateTime.Now.Hour);
            finishedGameVM.GameDateTime = finishedGameVM.GameDateTime.AddMinutes(DateTime.Now.Minute);
            foreach (var item in players)
            {
                var vm = new PlayerViewModel();
                vm.Id = item.Id;
                vm.Name = item.Name;
                vm.Email = item.Email;
                vmList.Add(vm);
            }
            if (players == null)
            {
                return NotFound();
            }
            finishedGameVM.PlayerList = vmList;
            return View(finishedGameVM);
        }

        // POST: FinishedGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( FinishedGameView VM)
        {
            FinishedGame fgEntity = new FinishedGame();
            if (VM != null && VM.Player1Name > 0)
            {
                //create list
                List<PlayerScore> psList = PlayerListFromVM(VM);
                
                //add data
                fgEntity.GameDateTime = VM.GameDateTime;
                fgEntity.Location = VM.Location;
                
                //Get placings
                Helpers.TournamentHelper th = new Helpers.TournamentHelper();
                psList = th.GetPlacingsAndPoints(psList);

                //Save data
                fgEntity.PlayerScores = psList;
                _context.FinishedGames.Add(fgEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(fgEntity);
        }

        // GET: FinishedGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finishedGame = await _context.FinishedGames.FindAsync(id);
            if (finishedGame == null)
            {
                return NotFound();
            }
            return View(finishedGame);
        }

        // POST: FinishedGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameDateTime,Location")] FinishedGame finishedGame)
        {
            if (id != finishedGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finishedGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinishedGameExists(finishedGame.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(finishedGame);
        }

        // GET: FinishedGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finishedGame = await _context.FinishedGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finishedGame == null)
            {
                return NotFound();
            }

            return View(finishedGame);
        }

        // POST: FinishedGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finishedGame = _context.FinishedGames.Include(i => i.PlayerScores).Where(i => i.Id == id).FirstOrDefault();
            _context.FinishedGames.Remove(finishedGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinishedGameExists(int id)
        {
            return _context.FinishedGames.Any(e => e.Id == id);
        }

        private List<PlayerScore> PlayerListFromVM(FinishedGameView VM)
        {
            List<PlayerScore> psList = new List<PlayerScore>();

            if (VM.Player1Score > 0)
            {
                PlayerScore p1 = new PlayerScore(); p1.VictoryPoints = VM.Player1Score;
                var p = _context.Players.First(i => i.Id == VM.Player1Name);

                if (p != null)
                {
                    p1.Player = p;
                }
                psList.Add(p1);
            }

            if (VM.Player2Score > 0)
            {
                PlayerScore p2 = new PlayerScore(); p2.VictoryPoints = VM.Player2Score;
                var p = _context.Players.First(i => i.Id == VM.Player2Name);

                if (p != null)
                {
                    p2.Player = p;
                }
                psList.Add(p2);
            }

            if (VM.Player3Score > 0)
            {
                PlayerScore p3 = new PlayerScore(); p3.VictoryPoints = VM.Player3Score;
                var p = _context.Players.First(i => i.Id == VM.Player3Name);

                if (p != null)
                {
                    p3.Player = p;
                }
                psList.Add(p3);
            }

            if (VM.Player4Score > 0)
            {
                PlayerScore p4 = new PlayerScore(); p4.VictoryPoints = VM.Player4Score;
                var p = _context.Players.First(i => i.Id == VM.Player4Name);

                if (p != null)
                {
                    p4.Player = p;
                }
                psList.Add(p4);
            }

            if (VM.Player5Score > 0)
            {
                PlayerScore p5 = new PlayerScore(); p5.VictoryPoints = VM.Player5Score;
                var p = _context.Players.First(i => i.Id == VM.Player5Name);

                if (p != null)
                {
                    p5.Player = p;
                }
                psList.Add(p5);
            }

            if (VM.Player6Score > 0)
            {
                PlayerScore p6 = new PlayerScore(); p6.VictoryPoints = VM.Player6Score;
                var p = _context.Players.First(i => i.Id == VM.Player6Name);

                if (p != null)
                {
                    p6.Player = p;
                }
                psList.Add(p6);
            }
            return psList;
        }
    }
}
