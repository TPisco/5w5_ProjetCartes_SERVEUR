using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Services;
using Super_Cartes_Infinies.Models;
using System.Collections;
using System.Security.Claims;
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
        public async Task<ActionResult> CreateDeck(string nom)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



            return Ok(await _decksService.CreateNewDeck(userId,nom));
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
