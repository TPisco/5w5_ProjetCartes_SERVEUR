using Microsoft.AspNetCore.Identity;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Microsoft.EntityFrameworkCore;


namespace Super_Cartes_Infinies.Services
{
	public class CardsService
    {
        private ApplicationDbContext _dbContext;

        public CardsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<IEnumerable<Card>> GetPlayersCards(string userId)
        {
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards)
                    .ThenInclude(oc => oc.Card)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (player == null)
                return Enumerable.Empty<Card>();

            return player.OwnedCards
                .Where(oc => oc.Card != null)
                .Select(oc => oc.Card)
                .ToList();
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _dbContext.Cards;
        }

       
    }
}
