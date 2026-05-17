using hedomi.application.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Services___tharwat.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDTO>> GetAllBrandsAsync();
        Task<BrandDTO?> GetBrandByIdAsync(int id);
        Task<BrandDTO?> GetBrandByNameAsync(string name);
        Task<BrandDTO?> GetBrandBySlugAsync(string slug);
        Task<BrandDTO> AddBrandAsync(CreateBrandDTO dto);
        Task<bool> UpdateBrandAsync(int id, UpdateBrandDTO dto);
        Task<bool> DeleteBrandAsync(int id);

    }
}
