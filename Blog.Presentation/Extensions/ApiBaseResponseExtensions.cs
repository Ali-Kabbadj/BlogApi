using Entities.Responses;

namespace Blog.Presentation.Extensions{
    public static class ApiBaseResponseExtensions{
        public static TResultType GetResult<TResultType>(this ApiBaseResponse apiBaseResponse) =>
            ((ApiOkResponse<TResultType>)apiBaseResponse).Result;
    }
}