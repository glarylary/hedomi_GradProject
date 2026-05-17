using hedomi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Repositories.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<Brand> GetByNameAsync(string name);
        Task<Brand> GetBySlugAsync(string slug);
    }

}
