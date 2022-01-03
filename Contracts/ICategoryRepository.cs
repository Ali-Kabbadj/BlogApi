﻿using Entities.Models;

namespace Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetCategoryAsync(Guid categoryId , bool trackChanges);
        void CreateCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<Guid> ids ,bool trackChanges);
        void DeleteCategoryAsync(Category category);

    }
}
