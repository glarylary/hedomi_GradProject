using hedomi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hedomi.infrastructure.AppDBcontext;
using hedomi.application.Repositories.Interfaces;

namespace hedomi.infrastructure.Implementation
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext context) : base(context)
        {
        }

        Task<IEnumerable<Category>> ICategoryRepository.SearchCategoryAsync(string searchTerm)
            => Task.FromResult(_context.Categories
                .Where(c => c.Name.Contains(searchTerm) || c.Slug.Contains(searchTerm))
                .AsEnumerable());

    }
}
