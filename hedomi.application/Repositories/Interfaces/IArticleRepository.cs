using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hedomi.domain;

namespace hedomi.application.Repositories.Interfaces
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
            Task<IEnumerable<Article>> GetArticlesByBrandIdAsync(int brandId);
            Task<IEnumerable<Article>> GetArticlesByCategoryIdAsync(int categoryId);
            Task<IEnumerable<Article>> GetArticlesByPriceRangeAsync(decimal minPrice, decimal maxPrice);
            Task<IEnumerable<Article>> SearchAsync(string searchTerm);
    }
}
