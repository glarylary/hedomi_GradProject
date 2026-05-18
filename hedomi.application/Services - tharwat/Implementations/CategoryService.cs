using AutoMapper;
using hedomi.application.DTOs.CatagoryDTO;
using hedomi.application.Repositories.Interfaces;
using hedomi.application.Services___tharwat.Interfaces;
using hedomi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Services___tharwat.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CatagoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CatagoryDTO>>(categories);
        }

        public async Task<CatagoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;
            return _mapper.Map<CatagoryDTO>(category);
        }

        public async Task<CatagoryDTO> AddCategoryAsync(CreateCatagoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(category);
            return _mapper.Map<CatagoryDTO>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            await _categoryRepository.DeleteAsync(category);
            return true;
        }
    }
}
