

namespace Entities.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(Guid categoryidId) :base ($"The category with id {categoryidId} does not exist in the database.") { }
    }
}
