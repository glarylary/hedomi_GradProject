using hedomi.application.DTOs.BrandDTOs;
using hedomi.application.Services___tharwat.Interfaces;
using hedomi.application.Services_tharwat.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hedomi_GradProject.Controllers
{
    [ApiController]
    [Route("brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // ── Public routes ─────────────────────────────────

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAllBrandsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _brandService.GetBrandByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _brandService.GetBrandByNameAsync(name);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var result = await _brandService.GetBrandBySlugAsync(slug);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // ── Admin routes ──────────────────────────────────

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CreateBrandDTO dto)
        {
            var result = await _brandService.AddBrandAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.BrandName }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateBrandDTO dto)
        {
            var success = await _brandService.UpdateBrandAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _brandService.DeleteBrandAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}