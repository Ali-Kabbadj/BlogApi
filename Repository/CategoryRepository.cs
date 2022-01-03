using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }


        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
               .OrderBy(a => a.Name)
                .ToListAsync();

        public async Task<Category> GetCategoryAsync(Guid categoryId, bool trackChanges)=>
            await FindByCondition(c => c.Id.Equals(categoryId), trackChanges)
            .SingleAsync();
        
        public void CreateCategoryAsync(Category category) => Create(category);

        public async Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

        public void DeleteCategoryAsync(Category category) => Delete(category);
    }
}
