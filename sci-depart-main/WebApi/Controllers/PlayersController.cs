using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.Models.Dtos;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Models.Models;
using WebApi.Configuration;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayersController : Controller
    {
        readonly UserManager<IdentityUser> _userManager;
        public PlayersService _playerService;
        private readonly JwtSettings _jwtSettings;

        public PlayersController(UserManager<IdentityUser> userManager, PlayersService playerService, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _playerService = playerService;
            _jwtSettings = jwtSettings;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les deux mots de passe spécifiés sont différents." });
            }
            IdentityUser identityUser = new IdentityUser()
            {
                UserName = register.Email,
                Email = register.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(identityUser, register.Password);
            if (!identityResult.Succeeded)
            {
                var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = $"La création de l'utilisateur a échoué: {errors}" });
            }

            Player player = _playerService.CreatePlayer(identityUser);
          


          

            return  Ok(new { Message = "Inscription réussie." });
        }


        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            IdentityUser? identityUser = await _userManager.FindByEmailAsync(login.Username);
            if (identityUser == null || !await _userManager.CheckPasswordAsync(identityUser, login.Password))
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Le nom d'utilisateur ou le mot de passe est invalide." });
            }

            Player player = _playerService.GetPlayerFromUserId(identityUser.Id);
            IList<string> roles = await _userManager.GetRolesAsync(identityUser);
            List<Claim> authClaims = new List<Claim>();
            foreach (string role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            authClaims.Add(new Claim("PlayerId", player.Id.ToString()));
            authClaims.Add(new Claim(ClaimTypes.NameIdentifier, identityUser.Id));
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_jwtSettings.Secret));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                validTo = token.ValidTo,
                playerId = identityUser.Id,
                username = identityUser.UserName,
                userIntID = player.Id
            });
        }

        [Authorize]
        [HttpGet]
        public ActionResult<string[]> PrivateData()
        {
            return new string[] { "figue", "banane", "noix" };
        }

        [Authorize]
        [HttpGet]
        public ActionResult<int> GetGold()
        {
            var userId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier)!;
            return _playerService.GetPlayerFromUserId(userId).Gold;
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task< ActionResult<int>> GetElo(string userId)
        {
            int Elo = _playerService.GetPlayerFromUserId(userId).ELO;
            return Elo;
        }
    }
    }

