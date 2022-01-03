
using Entities.Models;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryArticleExtention
    {
        public static IQueryable<Article> FilterArticles(this IQueryable<Article> 
            
            articles, DateTime minDate, DateTime maxDate) =>
            articles.Where(e => (e.CreatedDate>= minDate && e.CreatedDate <= maxDate));
            public static IQueryable<Article> Search(this IQueryable<Article> articles, 
            string searchTerm)
            {
            if (string.IsNullOrWhiteSpace(searchTerm))
            return articles;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return articles.Where(e => e.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Article> Sort(this IQueryable<Article> articles, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return articles.OrderBy(e => e.Title);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Article>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return articles.OrderBy(e => e.Title);

            return articles.OrderBy(orderQuery);

        }

    }
}