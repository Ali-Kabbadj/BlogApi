using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IArticleRepository
    {

        Task<PagedList<Article>> GetAllArticlesAsync(ArticleParameters articleParameters, bool trackChanges);
        Task<PagedList<Article>> GetAllArticlesInCategoryAsync(Guid categoryId, ArticleParameters articleParameters, bool trackChanges);
        Task<Article> GetArticleAsync(Guid articleId,Guid categoryId, bool trackChanges);
        void CreateArticleInCategory(Guid categoryId, Article article);
        void DeleteArticle(Article article);

    }
}
