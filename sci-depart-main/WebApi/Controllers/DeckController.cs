using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Services;
using Super_Cartes_Infinies.Models;
using System.Collections;
using System.Security.Claims;
using Models.Models;
using Models.Models.Dtos;


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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await _decksService.GetPlayerDecks(userId));
        }

        // GET: DeckController/Details/5
        // public ActionResult Details(int id)
        // {
        //  return View();
        //  }

        // GET: DeckController/Create
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Deck>>> SetCurrentDeck(int deckId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _decksService.SetCurrentDeckAsync(deckId, userId!));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateDeck([FromBody] CreateDeckDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            try
            {
                if (dto.CardIds != null && dto.CardIds.Any())
                    return Ok(await _decksService.CreateDeckWithCardsAsync(userId, dto.Name, dto.CardIds));
                return Ok(await _decksService.CreateNewDeck(userId, dto.Name));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateDeckLegacy(string nom)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _decksService.CreateNewDeck(userId, nom));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Deck>>> AddCard([FromBody] DeckCardActionDto dto) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            return Ok(await _decksService.AddCardToDeckAsync(dto.DeckId, dto.CardId, userId!));

        }





        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Deck>>> RemoveCard([FromBody] DeckCardActionDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            return Ok(await _decksService.RemoveCardFromDeckAsync(dto.DeckId, dto.CardId, userId!));

        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Deck>>> DeleteDeck( int deckId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            return Ok(await _decksService.DeleteDeckAsync(deckId, userId));

        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Card>>> GetAvailableCards(int deckId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            return Ok(await _decksService.GetAvailableCardsForDeckAsync(deckId, userId));
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetDeckLimits()
        {
            return Ok(_decksService.GetDeckLimits());
        }




        // POST: DeckController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DeckController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DeckController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: DeckController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: DeckController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return Ok();
        //    }
        //}
    }
}
