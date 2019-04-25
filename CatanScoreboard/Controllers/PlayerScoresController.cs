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
    public class PlayerScoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerScoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerScores
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayerScores.ToListAsync());
        }

        // GET: PlayerScores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerScore = await _context.PlayerScores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerScore == null)
            {
                return NotFound();
            }

            return View(playerScore);
        }

        // GET: PlayerScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VictoryPoints,Placed,TournamentPoints")] PlayerScore playerScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerScore);
        }

        // GET: PlayerScores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerScore = await _context.PlayerScores.FindAsync(id);
            if (playerScore == null)
            {
                return NotFound();
            }
            return View(playerScore);
        }

        // POST: PlayerScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VictoryPoints,Placed,TournamentPoints")] PlayerScore playerScore)
        {
            if (id != playerScore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerScoreExists(playerScore.Id))
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
            return View(playerScore);
        }

        // GET: PlayerScores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerScore = await _context.PlayerScores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerScore == null)
            {
                return NotFound();
            }

            return View(playerScore);
        }

        // POST: PlayerScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerScore = await _context.PlayerScores.FindAsync(id);
            _context.PlayerScores.Remove(playerScore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerScoreExists(int id)
        {
            return _context.PlayerScores.Any(e => e.Id == id);
        }
    }
}
