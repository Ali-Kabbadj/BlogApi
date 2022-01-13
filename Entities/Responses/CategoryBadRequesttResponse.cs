namespace Entities.Responses{
    public sealed class CategoryBadRequesttResponse : ApiBadRequestResponse {
        public CategoryBadRequesttResponse() 
            : base("Something went wrong while trying to process the client's request.")
            { }
    }
    
}