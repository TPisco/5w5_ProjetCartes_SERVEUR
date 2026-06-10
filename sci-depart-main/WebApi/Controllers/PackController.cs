using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackController : ControllerBase
    {
        private readonly PacksService _packsService;

        public PackController(PacksService packsService)
        {
            _packsService = packsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPacks()
        {
            return Ok(await _packsService.GetAllPacksAsync());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BuyPack(int packId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            try
            {
                return Ok(await _packsService.BuyPackAsync(userId, packId));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
