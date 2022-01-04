using Entities.Models;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IArticleLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<ArticleDto> articlesDto, string fields, Guid categoryId, HttpContext httpContext);
    }
}