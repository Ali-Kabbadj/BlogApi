

namespace Entities.Exceptions
{
    public sealed class ArticleNotFoundException : NotFoundException
    {
        public ArticleNotFoundException(Guid articleId) :base ($"The article with id {articleId} does not exist in the database.") { }
    }
}
