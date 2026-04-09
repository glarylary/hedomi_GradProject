using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hedomi.domain;
using hedomi.infrastructure.AppDBcontext;
using hedomi.infrastructure.Repositories.Interfaces;

namespace hedomi.infrastructure.Implementation
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Article>> GetArticlesByBrandIdAsync(int brandId)
        => await _context.Articles
            .Where(a => a.BrandID == brandId)
            .Include(a => a.Brand)
            .ToListAsync();
        public async Task<IEnumerable<Article>> GetArticlesByCategoryIdAsync(int categoryId)
            => await _context.Articles
                .Where(a => a.Category.CategoryID == categoryId)
                .Include(a => a.Brand)
                .Include(a => a.Category)
                .ToListAsync();
        public async Task<IEnumerable<Article>> GetArticlesByPriceRangeAsync(decimal minPrice, decimal maxPrice)
            => await _context.Articles
                .Where(a => a.Price >= minPrice && a.Price <= maxPrice)
                .Include(a => a.Brand)
                .ToListAsync();

        public async Task<IEnumerable<Article>> SearchAsync(string searchTerm)
            => await _context.Articles
                .Where(a => a.Name.Contains(searchTerm) || a.Description.Contains(searchTerm) || a.SKU.Contains(searchTerm))
                .Include(a => a.Brand)
                .ToListAsync();

    }
}
