using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hedomi.domain;
using hedomi.infrastructure.AppDBcontext;
using hedomi.infrastructure.Repositories.Interfaces;

namespace hedomi.infrastructure.Implementation
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDBContext context) : base(context)
        {
        }
        public async Task<Brand> GetByNameAsync(string name)
            => await _context.Brands
            .Include(b => b.Articles)
            .FirstOrDefaultAsync(b => b.BrandName == name);

        public async Task<Brand> GetBySlugAsync(string slug)
            => await _context.Brands
            .FirstOrDefaultAsync(b => b.Slug == slug);
    }
}
