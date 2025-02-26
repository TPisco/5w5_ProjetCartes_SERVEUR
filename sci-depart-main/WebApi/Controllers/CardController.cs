using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private CardsService _cardsService;

        public CardController(ApplicationDbContext dbContext, CardsService cardsService)
        {
            _dbContext = dbContext;
            _cardsService = cardsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            return Ok(_cardsService.GetAllCards());
        }

        // TODO: La version réelle devra utiliser [Authorize] pour protéger les données est s'assurer d'avoir accès au User
        // Et l'utiliser pour obtenir l'Id de l'utilisateur
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetPlayersCards()
        {
            return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser"));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create()
        {
           
            String? name = Request.Form["name"];
            String? manaString = Request.Form["mana"];
            String? attackString = Request.Form["attack"];
            String? healthString = Request.Form["health"];
            String? url = Request.Form["url"];

            
            int mana = int.Parse(manaString);
            int attack = int.Parse(attackString);
            int health = int.Parse(healthString);

           

            Card? newCard = await _cardsService.CreateCard(name, mana, health, attack, url);

            
            if (newCard == null)
                return StatusCode(StatusCodes.Status500InternalServerError);


            return Ok(newCard);
        }

        // POST: CardsController/Edit/5

        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int cardId)
        {
            String? name = Request.Form["name"];
            String? manaString = Request.Form["mana"];
            String? attackString = Request.Form["attack"];
            String? healthString = Request.Form["health"];
            String? url = Request.Form["url"];

            int mana = int.Parse(manaString);
            int attack = int.Parse(attackString);
            int health = int.Parse(healthString);

            

            Card? updatedCard = await _cardsService.EditCard(cardId, name, mana, health, attack, url);

            if (updatedCard == null)
                return StatusCode(StatusCodes.Status404NotFound); // Card not found

            return Ok(updatedCard);
        }

      
        // POST: CardsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
           
            bool success = await _cardsService.DeleteCard(id);

            if (!success)
                return StatusCode(StatusCodes.Status404NotFound); // Card not found

            return RedirectToAction(nameof(GetAllCards)); 
        }
    }
}
