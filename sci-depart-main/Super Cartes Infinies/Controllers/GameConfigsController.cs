using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Controllers
{

    [Authorize(Roles = "adminRole")]
    public class GameConfigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameConfigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameConfigs
        public async Task<IActionResult> Index()
        {
            var gameConfig = await _context.GameConfigs.FindAsync(1);
            if (gameConfig == null)
            {
                return NotFound();
            }
            return View(gameConfig);
        }

        // POST: GameConfigs
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("id,QtManaParTour,nbCardsToDraw")] GameConfig gameConfig)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameConfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameConfigExists(gameConfig.id))
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
            return View(gameConfig);
        }

        private bool GameConfigExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }

    }
}
