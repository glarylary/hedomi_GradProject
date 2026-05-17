using hedomi.application.DTOs.ArticleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Services___tharwat.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDTO>> GetAllArticlesAsync();
        Task<ArticleDTO?> GetArticleByIdAsync(int id);
        Task<IEnumerable<ArticleDTO>> GetArticlesByBrandIdAsync(int brandId);
        Task<IEnumerable<ArticleDTO>> GetArticlesByCategoryIdAsync(int categoryId);
        Task<IEnumerable<ArticleDTO>> GetArticlesByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<ArticleDTO>> SearchArticlesAsync(string searchTerm);
        Task<ArticleDTO> CreateArticleAsync(CreateArticleDTO dto);
        Task<bool> UpdateArticleAsync(int id, UpdateArticleDTO dto);
        Task<bool> DeleteArticleAsync(int id);
    }
}
