using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Repository.Extensions;

namespace Repository
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

      

        public async Task<Article> GetArticleAsync(Guid articleId, Guid categoryid, bool trackChanges) =>
         await FindByCondition(c => c.CategoryId.Equals(categoryid) && c.Id.Equals(articleId), trackChanges)
            .FirstAsync();
        

        public async Task<PagedList<Article>> GetAllArticlesAsync(Guid categoryId, ArticleParameters articleParameters, bool trackChanges)
        {
            var articles = await FindByCondition(e => e.CategoryId.Equals(categoryId) ,trackChanges)
            .FilterArticles(articleParameters.MinCreatedDate, articleParameters.MaxCreatedDate )  
            .Search(articleParameters.SearchTerm)
            .OrderBy(e => e.CreatedDate)
            .Skip((articleParameters.PageNumber - 1) * articleParameters.PageSize)
            .Take(articleParameters.PageSize)
            .ToListAsync();
            var count = await FindByCondition(e => e.CategoryId.Equals(categoryId), trackChanges).CountAsync();
            return new PagedList<Article>(articles, count,articleParameters.PageNumber, articleParameters.PageSize);
        }

        public async Task<IEnumerable<Article>> GetAllArticlesPageListAsync(Guid categoryId, ArticleParameters articleParameters, bool trackChanges) =>
         await FindByCondition(e => e.Category.Id.Equals(categoryId), trackChanges)
         .OrderBy(e => e.CreatedDate)
         .Skip((articleParameters.PageNumber - 1) * articleParameters.PageSize)
         .Take(articleParameters.PageSize)
         .ToListAsync();

        public void CreateArticleInCategory(Guid categoryId,Article article)
        {
            article.CategoryId = categoryId;
            article.CreatedDate = DateTime.UtcNow;
            Create(article);
        }

        public void DeleteArticle(Article article) => Delete(article);

    }

}
