using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;

        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
         }

        private async Task<Category> GetCategoryAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var company = await _repository.CategoryRepository.GetCategoryAsync(id, trackChanges);
            if (company is null)
                throw new CategoryNotFoundException(id);
            return company;
        }


        public async Task<CategoryDto> GetCategoryAsync(Guid categoryId, bool trackChanges)
        {
            var category = await GetCategoryAndCheckIfItExists(categoryId,trackChanges);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _repository.CategoryRepository.GetAllCategoriesAsync(trackChanges);
            var categoriesDot = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesDot;
        }

        public async Task<IEnumerable<CategoryDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var categoryEntities = await _repository.CategoryRepository.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != categoryEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            return categoriesToReturn;
        }


        public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.CategoryRepository.CreateCategoryAsync(categoryEntity);
            await _repository.SaveAsync();
            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
            return categoryToReturn;

        }






        public async Task<(IEnumerable<CategoryDto> categories, string ids)> CreateCategoryCollectionAsync(IEnumerable<CategoryForCreationDto> categoryCollection)
        {
            if (categoryCollection is null)
                throw new CategoryCollectionBadRequest();
            var categoryEntities = _mapper.Map<IEnumerable<Category>>(categoryCollection);
            foreach (var category in categoryEntities)
            {
                _repository.CategoryRepository.CreateCategoryAsync(category);
            }
            await _repository.SaveAsync();
            var categoryCollectionToReturn =
            _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            var ids = string.Join(",", categoryCollectionToReturn.Select(c => c.Id));
            return (categories: categoryCollectionToReturn, ids);
        }

        public async Task DeleteCategoryAsync(Guid categoryId,bool trackChangers)
        {
            var category =  await GetCategoryAndCheckIfItExists(categoryId, trackChangers);
            _repository.CategoryRepository.DeleteCategoryAsync(category);
            await _repository.SaveAsync();
        }


        public async Task UpdateCategoryAsync(Guid categoryId,CategoryForUpdateDto categoryForUpdate ,bool trackChanges)
        {
            var categoryDb = await GetCategoryAndCheckIfItExists(categoryId, trackChanges);
            _mapper.Map(categoryForUpdate,categoryDb);
            await _repository.SaveAsync();
        }
    }
}