using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Services;
using Super_Cartes_Infinies.Models;
using System.Collections;
using System.Security.Claims;
using Models.Models.Dtos;
using Models.Models;


namespace WebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeckController : ControllerBase
    {

        private ApplicationDbContext _dbContext;
        private DecksService _decksService;
        // GET: DeckController

        public DeckController(ApplicationDbContext dbContext, DecksService decksService)
        {
            _dbContext = dbContext;
            _decksService = decksService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Deck>>> GetPlayerDecks()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



           if(userId!= null)  return Ok(await _decksService.GetPlayerDecks(userId));

            return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "La recherche de decks a échoué." });

        }


        //[HttpGet]
        //[Authorize]
        //public async Task<ActionResult<IEnumerable<OwnedCards>>> GetCardsNotInDeck(int deckId)
        //{
        //    string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (string.IsNullOrEmpty(userId)) return Unauthorized();

        //    var cardsNotInDeck = await _decksService.GetCardsNotInDeck(deckId, userId);
        //    return Ok(cardsNotInDeck);
        //}



        // GET: DeckController/Create
        [HttpPost]
        public async Task<ActionResult> CreateDeck(DeckDTO deckDto)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();




            return Ok(await _decksService.CreateNewDeck(userId, deckDto.Deckname));
        }

        //[HttpPost]
        //[Authorize]
        //public async Task<ActionResult<Deck>> RendreCourant(int deckId)
        //{
        //    string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (string.IsNullOrEmpty(userId)) return Unauthorized();

        //    var updatedDeck = await _decksService.SetDeckAsCurrent(deckId, userId);

        //    if (updatedDeck == null)
        //        return NotFound("Deck not found or does not belong to the user.");

        //    return Ok(updatedDeck);
        //}



        [HttpPost]
        public async Task<ActionResult<IEnumerable<Deck>>> AddCard(int ownedCardId, int deckId) {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            return Ok(await _decksService.AddCardToDeckAsync(deckId, ownedCardId, userId));

        }





        [HttpPost]
        public async Task<ActionResult<IEnumerable<Deck>>> RemoveCard(int cardId, int deckId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();



            return Ok(await _decksService.RemoveCardFromDeckAsync(deckId, cardId, userId));

        }


        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Deck>>> DeleteDeck( int deckId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);




            return Ok(await _decksService.DeleteDeckAsync(deckId, userId));

        }


        // GET: DeckController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
