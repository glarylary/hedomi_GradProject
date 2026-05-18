using AutoMapper;
using hedomi.application.DTOs.BrandDTOs;
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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandDTO>>(brands);
        }


        public async Task<BrandDTO?> GetBrandByNameAsync(string name)
        {
            var brand = await _brandRepository.GetByNameAsync(name);
            if (brand == null) return null;
            return _mapper.Map<BrandDTO>(brand);
        }
        public async Task<BrandDTO?> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return null;
            return _mapper.Map<BrandDTO>(brand);
        }


        public async Task<BrandDTO?> GetBrandBySlugAsync(string slug)
        {
            var brand = await _brandRepository.GetBySlugAsync(slug);
            if (brand == null) return null;
            return _mapper.Map<BrandDTO>(brand);
        }

        public async Task<BrandDTO> AddBrandAsync(CreateBrandDTO dto)
        {
            var brand = _mapper.Map<Brand>(dto);
            await _brandRepository.AddAsync(brand);
            return _mapper.Map<BrandDTO>(brand);
        }

        public async Task<bool> UpdateBrandAsync(int id, UpdateBrandDTO dto)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return false;
            _mapper.Map(dto, brand);
            await _brandRepository.UpdateAsync(brand);
            return true;
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return false;
            await _brandRepository.DeleteAsync(brand);
            return true;
        }
    }
}
