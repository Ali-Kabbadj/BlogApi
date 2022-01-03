using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IArticleService
    {
        Task<(IEnumerable<ArticleDto> articles, MetaData metaData)> GetAllArticlesAsync (Guid categoryId,ArticleParameters articleParameters,bool trackChanges);
        Task<ArticleDto> GetArticleAsync(Guid articleId,Guid categoryId , bool trackChanges);
        Task<ArticleDto> CreateArticleForCategoryAsync(Guid categoryId, ArticleForCreationDto articleForCreation, bool trackChanges);
        Task DeleteArticleInCategoryAsync(Guid categoryId ,Guid Id , bool trackChanges);
        Task UpdateArticleInCategoryAsync(Guid categoryId, Guid Id,ArticleForUpdateDto articleFordate, bool compTrackChanges ,bool empTrackChanger);

        Task<(ArticleForUpdateDto articleToPatch, Article articleEntity)> GetArticleForPatchAsync(Guid categoryId, Guid id, bool compTrackChanges, bool empTrackChanges);
        Task SaveChangesForPatchAsync(ArticleForUpdateDto articleToPatch, Article articleEntity);

     


    }
}