using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager :IServiceManager
    {
        private readonly Lazy<IArticleService> _articleService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ITagService> _tagService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger , IMapper mapper ,IArticleLinks articleLinks)
        {
            _articleService = new Lazy<IArticleService>(() => new
                ArticleService(repositoryManager, logger ,mapper,articleLinks));

            _categoryService = new Lazy<ICategoryService>(() => new
                CategoryService(repositoryManager, logger ,mapper));

            _tagService = new Lazy<ITagService>(() => new
                TagService(repositoryManager, logger , mapper));

         

        }

        public IArticleService ArticleService => _articleService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public ITagService TagService => _tagService.Value;



    }
}
