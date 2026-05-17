using AutoMapper;
using hedomi.application.DTOs.ArticleDTOs;
using hedomi.application.Repositories.Interfaces;
using hedomi.application.Services___tharwat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Services___tharwat.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleDTO>> GetAllArticlesAsync()
        {
            var articles = await _articleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }

        public async Task<ArticleDTO?> GetArticleByIdAsync(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return article == null ? null : _mapper.Map<ArticleDTO>(article);
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesByBrandIdAsync(int brandId)
        {
            var articles = await _articleRepository.GetArticlesByBrandIdAsync(brandId);
            return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesByCategoryIdAsync(int categoryId)
        {
            var articles = await _articleRepository.GetArticlesByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var articles = await _articleRepository.GetArticlesByPriceRangeAsync(minPrice, maxPrice);
            return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }

        public async Task<IEnumerable<ArticleDTO>> SearchArticlesAsync(string searchTerm)
        {
            var articles = await _articleRepository.SearchAsync(searchTerm);
            return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }

        //admin article management

        public async Task<ArticleDTO> CreateArticleAsync(CreateArticleDTO dto)
        {
            var article = _mapper.Map<domain.Article>(dto);
            await _articleRepository.AddAsync(article);
            return _mapper.Map<ArticleDTO>(article);
        }

        public async Task<bool> UpdateArticleAsync(int id, UpdateArticleDTO dto)
        {
            var exists = await _articleRepository.ExistAsync(id);
            if (!exists) return false;

            var article = _mapper.Map<domain.Article>(dto);
            await _articleRepository.UpdateAsync(article);
            return true;
        }
        public async Task<bool> DeleteArticleAsync(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            if (article == null) return false;
            await _articleRepository.DeleteAsync(article);
            return true;
        }
    }

}
