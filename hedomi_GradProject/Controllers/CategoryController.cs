using hedomi.application.DTOs.CatagoryDTO;
using hedomi.application.Services___tharwat.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hedomi_GradProject.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // ── Public routes ─────────────────────────────────

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }


        // ── Admin routes ──────────────────────────────────

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CreateCatagoryDTO dto)
        {
            var result = await _categoryService.AddCategoryAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Name }, result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
