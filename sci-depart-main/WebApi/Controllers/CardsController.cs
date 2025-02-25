using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace WebApi.Controllers
{
    public class CardsController : Controller
    {
        private readonly CardsService _cardsService;

        public CardsController(CardsService cardsService)
        {
            _cardsService = cardsService;
        }

        // GET: CardsController
        public ActionResult Index()
        {
            return View();
        }




        // GET: CardsController/Create
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


            Card? newCard = await _cardsService.CreateCard(name,mana,health,attack,url);
            if (newCard == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(newCard);
        }


        // POST: CardsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }





        // GET: CardsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }






        // GET: CardsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: CardsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
