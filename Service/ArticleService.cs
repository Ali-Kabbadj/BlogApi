using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Dynamic;
using System.Net.Http.Headers;

namespace Service
{
    internal sealed class ArticleService : IArticleService
    {
        private readonly IRepositoryManager _repository;

        private readonly ILoggerManager _logger;

        private readonly IMapper _mapper;

        private readonly IArticleLinks _articleLinks;

        public ArticleService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IArticleLinks articleLinks)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _articleLinks = articleLinks;
        }


        private async Task CheckIfCategoryExists(Guid categoryId, bool trackChanges)
        {
            try
            {
                var company = await _repository.CategoryRepository.GetCategoryAsync(categoryId, trackChanges);
            }
            catch
            {
                throw new CategoryNotFoundException(categoryId);
            }
        }


        private async Task<Article> GetArticleInCategoryAndCheckIfItExists(Guid categoryId, Guid id, bool trackChanges)
        {
            var articleDb = await _repository.ArticleRepository.GetArticleAsync(id, categoryId, trackChanges);
            if (articleDb is null)
                throw new ArticleNotFoundException(id);
            return articleDb;
        }




        public async Task<ArticleDto> GetArticleAsync(Guid articleId, Guid categoryId, bool trackChanges)
        {
            await CheckIfCategoryExists(categoryId, trackChanges);
            var articleDb = await GetArticleInCategoryAndCheckIfItExists(categoryId, articleId, trackChanges);
            var articleDto = _mapper.Map<ArticleDto>(articleDb);
            return articleDto;
        }


        public async Task<ArticleDto> CreateArticleForCategoryAsync(Guid categoryId, ArticleForCreationDto articleForCreation, bool trackChanges)
        {
            await CheckIfCategoryExists(categoryId, trackChanges);
            var articleEntity = _mapper.Map<Article>(articleForCreation);
            _repository.ArticleRepository.CreateArticleInCategory(categoryId, articleEntity);
            await _repository.SaveAsync();
            var articleToReturn = _mapper.Map<ArticleDto>(articleEntity);
            return articleToReturn;
        }

        public async Task DeleteArticleInCategoryAsync(Guid categoryId, Guid id, bool trackChanges)
        {
            await CheckIfCategoryExists(categoryId, trackChanges);
            var articleDb = await GetArticleInCategoryAndCheckIfItExists(categoryId, id, trackChanges);
            _repository.ArticleRepository.DeleteArticle(articleDb);
            await _repository.SaveAsync();
        }

        public async Task UpdateArticleInCategoryAsync(Guid categoryId, Guid id, ArticleForUpdateDto articleForUpdate, bool compTrackChanges, bool empTrackChanges)
        {
            await CheckIfCategoryExists(categoryId, compTrackChanges);
            var articleDb = await GetArticleInCategoryAndCheckIfItExists(categoryId, id, empTrackChanges);
            _mapper.Map(articleForUpdate, articleDb);
            await _repository.SaveAsync();

        }

        public async Task<(ArticleForUpdateDto articleToPatch, Article articleEntity)> GetArticleForPatchAsync(Guid categoryId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            await CheckIfCategoryExists(categoryId, compTrackChanges);
            var articleDb = await GetArticleInCategoryAndCheckIfItExists(categoryId, id, empTrackChanges);
            var articleToPatch = _mapper.Map<ArticleForUpdateDto>(articleDb);
            return (articleToPatch, articleDb);

        }

        public async Task SaveChangesForPatchAsync(ArticleForUpdateDto articleToPatch, Article articleDb)
        {
            _mapper.Map(articleToPatch, articleDb);
            await _repository.SaveAsync();
        }


        public async Task<(LinkResponse linkResponse, MetaData metaData)> GetAllArticlesAsync(Guid categoryId, LinkParameters linkParameters, bool trackChanges)
        {
            if (!linkParameters.ArticleParameters.ValidCreatedDateRange)
                throw new MaxCreateDateRangeBadRequestExeption();

            await CheckIfCategoryExists(categoryId, trackChanges);

            var articlesWithMetaData = await _repository.ArticleRepository
                .GetAllArticlesAsync(categoryId, linkParameters.ArticleParameters,trackChanges);

            var articlesDto = _mapper.Map<IEnumerable<ArticleDto>>(articlesWithMetaData);

            var links = _articleLinks.TryGenerateLinks(articlesDto,linkParameters.ArticleParameters.Fields,categoryId, linkParameters.Context);
            
            return (linkResponse: links, metaData: articlesWithMetaData.MetaData);

        }




    }
}