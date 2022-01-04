using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IArticleService ArticleService { get; }
        ICategoryService CategoryService { get; }
        ITagService TagService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
