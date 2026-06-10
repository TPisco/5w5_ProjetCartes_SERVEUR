using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Controllers
{
    [Authorize(Roles = "admin")]
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Attack,Health,Cost,ImageUrl,Rarity")] Card card)
        {
          

            if (ModelState.IsValid)
            {
                _context.Cards.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            //var card = await _context.Cards.FindAsync(id);

            var card = await _context.Cards.Include(c => c.CardPowers).ThenInclude(cp => cp.Power).FirstOrDefaultAsync(m => m.Id == id);

            if (card == null)
            {
                return NotFound();
            }

            var existingPower = card.CardPowers.Select(cp => cp.PowerId).ToList();

            // Récupère données depuis BD
            var allPowers = await _context.Power
                .Where(p => !existingPower.Contains(p.Id))
                .ToListAsync();

            // Filtre la liste des pouvoirs par ID pour avoir que des uniques.
            var availablePowers = allPowers
                .DistinctBy(p => p.Id)
                .ToList();

            bool allPowersAdded = availablePowers.Count == 0;
            ViewData["AllPowersAdded"] = allPowersAdded;

            ViewBag.AllPowers = availablePowers;
            return View(card);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Power(int id, int selectedPowers, int powerValues)
        {
            var card = await _context.Cards.FindAsync(id);
            
            if (card == null) { return NotFound(); }
            
                // Je créer un CardPower avec les valeurs du formulaires
                var cardPower = new CardPower
                {
                    CardId = card.Id,
                    PowerId = selectedPowers,
                    Value = powerValues
                };

                _context.cardPowers.Add(cardPower);
                await _context.SaveChangesAsync();

                ViewBag.AllPowers = _context.Power.ToList();
                return RedirectToAction("Edit", new { id = card.Id });

            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePower(int powerId, int cardId)
        {

            var cardPower = await _context.cardPowers
                .FirstOrDefaultAsync(cp => cp.CardId == cardId && cp.PowerId == powerId);
            
            if (cardPower == null)
            {
                return NotFound();
            }

            _context.cardPowers.Remove(cardPower);
            await _context.SaveChangesAsync();


            // IL Y A PEUT ETRE UNE ERREUR ICI
            return RedirectToAction("Edit", new { id = cardId });
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int selectedPowers, int powerValues, [Bind("Id,Name,Attack,Health,Cost,ImageUrl,Rarity")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Cards.Update(card);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
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
            ViewBag.AllPowers = _context.Power.ToList();
            return View(card);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    }
}
