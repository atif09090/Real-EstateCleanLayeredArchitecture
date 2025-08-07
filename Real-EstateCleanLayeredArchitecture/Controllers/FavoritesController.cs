using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Real_EstateCleanLayeredArchitecture.Services.Interfaces;

namespace Real_EstateCleanLayeredArchitecture.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _service;
        public FavoritesController(IFavoriteService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await _service.GetFavoritesAsync(userId));
        }

        [HttpPost("{propertyId}")]
        public async Task<IActionResult> Toggle(Guid propertyId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await _service.ToggleFavoriteAsync(userId, propertyId));
        }
    }
}
