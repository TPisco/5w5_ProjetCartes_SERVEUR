using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MatchController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetOngoingMatches()
        {
            var matches = await _dbContext.Matches
                .Include(m => m.PlayerDataA).ThenInclude(pd => pd.Player)
                .Include(m => m.PlayerDataB).ThenInclude(pd => pd.Player)
                .Where(m => !m.IsMatchCompleted)
                .Select(m => new
                {
                    m.Id,
                    PlayerA = m.PlayerDataA.Player.Name,
                    PlayerB = m.PlayerDataB.Player.Name,
                    m.IsPlayerATurn
                })
                .ToListAsync();
            return Ok(matches);
        }
    }
}
