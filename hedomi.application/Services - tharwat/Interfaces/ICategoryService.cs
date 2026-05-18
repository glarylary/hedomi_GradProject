using hedomi.application.DTOs.CatagoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Services___tharwat.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CatagoryDTO>> GetAllCategoriesAsync();
        Task<CatagoryDTO?> GetCategoryByIdAsync(int id);
        Task<CatagoryDTO> AddCategoryAsync(CreateCatagoryDTO dto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
