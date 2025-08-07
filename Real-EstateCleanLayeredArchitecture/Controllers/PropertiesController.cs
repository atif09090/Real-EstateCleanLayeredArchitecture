using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_EstateCleanLayeredArchitecture.DTOs;
using Real_EstateCleanLayeredArchitecture.Services;
using Real_EstateCleanLayeredArchitecture.Services.Interfaces;

namespace Real_EstateCleanLayeredArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _service;
        public PropertiesController(IPropertyService service) => _service = service;

        [HttpGet("Get-All-Properties")]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpGet("Get-Property-By-Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var prop = await _service.GetByIdAsync(id);
            return prop == null ? NotFound() : Ok(prop);
        }

        [HttpPost("Get-Property-By-Filters")]
        public async Task<IActionResult> GetPropertyByFilters(PropertySearchDto filters)
        {
            var result = await _service.SearchPropertiesAsync(filters);
            return Ok(result);
        }


        [HttpPost("Create-Property")]
        public async Task<IActionResult> Create(CreatePropertyDto dto) => Ok(await _service.CreateAsync(dto));
    }
}
