using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace WebApi.Controllers
{
    public class StartingCardsController : Controller
    {
        private readonly StartingCardsService _startingCardsService;

        StartingCardsController( StartingCardsService startingCardsService)
        {
            _startingCardsService = startingCardsService;
        }


        // GET: StartingCardsController
        public ActionResult Index(string? name)
        {

            List<Card> startingCards = _startingCardsService.GetStartingCards();

            if (name == null)
            {
                List<Card> sortedCards = startingCards.OrderBy(c => c.Name).ToList();
                return View(sortedCards);
            }
            else
            {
                List<Card> selectedCards = startingCards.Where(c => c.Name.Contains(name)).ToList();
                List<Card> sortedCards = selectedCards.OrderBy(c => c.Name).ToList();
                return View(sortedCards);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStartingCards(List<int> selectedCardIds)
        {
            if (selectedCardIds == null || selectedCardIds.Count == 0)
            {
                return BadRequest("Aucune carte sélectionnée.");
            }

            _startingCardsService.UpdateStartingCards(selectedCardIds);

            return RedirectToAction(nameof(Index));
        }


    }
}
