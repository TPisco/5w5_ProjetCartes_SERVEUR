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

    [Authorize(Roles = "admin")]
    public class StartingCardsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public StartingCardsController(ApplicationDbContext context)
        {
            _context = context;
        }




        // GET: StartingCardsController
        public async Task<ActionResult> Index(string? name)
        {
            

            List<StartingCards> startingCards = _context.StartingCards.Include(c=>c.Card).ToList();

            foreach(StartingCards s in startingCards)
            {
                s.Card = await _context.Cards.FindAsync(s.CardID);
            }

            if (name == null)
            {
                List<StartingCards> sortedCards = startingCards.OrderBy(c => c.Card.Name).ToList();
                return View(sortedCards);
            }
            else
            {
                List<StartingCards> selectedCards = startingCards.Where(c => c.Card.Name.Contains(name)).ToList();
                List<StartingCards> sortedCards = selectedCards.OrderBy(c => c.Card.Name).ToList();
                return View(sortedCards);
            }
        }

        // POST: StartingCards/AddStartingCard/5
        public async Task<ActionResult> AddStartingCard(int id)
        {
          
            Card Card = await _context.Cards.FindAsync(id);
            if (Card == null)
            {
                return BadRequest();
            }

            StartingCards startingCard = new StartingCards()
            {
                CardID = id,
                Card = Card
            };

            if (startingCard != null)
            {
              _context.StartingCards.Add(startingCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


      

        // GET: StartingCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startingCards = await _context.StartingCards
                .Include(s => s.Card)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (startingCards == null)
            {
                return NotFound();
            }

            return View(startingCards);
        }

        // POST: StartingCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var startingCards = await _context.StartingCards.FindAsync(id);
            if (startingCards != null)
            {
                _context.StartingCards.Remove(startingCards);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StartingCardsExists(int id)
        {
            return _context.StartingCards.Any(e => e.Id == id);
        }
    }
}
