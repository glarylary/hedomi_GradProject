using hedomi.application.DTOs.ArticleDTOs;
using hedomi.application.Services___tharwat.Interfaces;
using hedomi.application.Services_tharwat.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hedomi_GradProject.Controllers
{
    [ApiController]
    [Route("articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // ── Public routes ─────────────────────────────────

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _articleService.GetAllArticlesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _articleService.GetArticleByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("brand/{brandId}")]
        public async Task<IActionResult> GetByBrand(int brandId)
        {
            var result = await _articleService.GetArticlesByBrandIdAsync(brandId);
            return Ok(result);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var result = await _articleService.GetArticlesByCategoryIdAsync(categoryId);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string searchTerm)
        {
            var result = await _articleService.SearchArticlesAsync(searchTerm);
            return Ok(result);
        }

        [HttpGet("price-range")]
        public async Task<IActionResult> GetByPriceRange(
            [FromQuery] decimal minPrice,
            [FromQuery] decimal maxPrice)
        {
            var result = await _articleService.GetArticlesByPriceRangeAsync(minPrice, maxPrice);
            return Ok(result);
        }

        // ── Admin routes ──────────────────────────────────

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CreateArticleDTO dto)
        {
            var result = await _articleService.CreateArticleAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.ArticleID }, result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateArticleDTO dto)
        {
            var success = await _articleService.UpdateArticleAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _articleService.DeleteArticleAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}