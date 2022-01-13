namespace Entities.Responses{
    public sealed class CategoryNotFoundResponse : ApiNotFoundResponse {
        public CategoryNotFoundResponse(Guid id) 
            : base($"Category with id: {id} is not found in db.")
            { }
    }
}