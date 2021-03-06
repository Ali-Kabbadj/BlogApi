using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager :IServiceManager
    {
        private readonly Lazy<IArticleService> _articleService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ITagService> _tagService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger , IMapper mapper ,IArticleLinks articleLinks,UserManager<User> userManager,RoleManager<IdentityRole> roleManager ,IOptions<JwtConfiguration> configuration)
        {
            _articleService = new Lazy<IArticleService>(() => new
                ArticleService(repositoryManager, logger ,mapper,articleLinks));

            _categoryService = new Lazy<ICategoryService>(() => new
                CategoryService(repositoryManager, logger ,mapper));

            _tagService = new Lazy<ITagService>(() => new
                TagService(repositoryManager, logger , mapper));
           _authenticationService = new Lazy<IAuthenticationService>(() =>new 
           AuthenticationService(logger, mapper, userManager,roleManager, configuration ));

        }

         

        

        public IArticleService ArticleService => _articleService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public ITagService TagService => _tagService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;



    }
}
