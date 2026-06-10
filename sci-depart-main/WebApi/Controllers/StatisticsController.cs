using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StatisticsController : ControllerBase
    {
        private readonly StatisticsService _statisticsService;

        public StatisticsController(StatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayerStats()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            return Ok(await _statisticsService.GetPlayerStatisticsAsync(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetCardDistribution(int? deckId = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            return Ok(await _statisticsService.GetCardDistributionAsync(userId, deckId));
        }
    }
}
