using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IArticleRepository> _articleRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ITagRepository> _tagRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _articleRepository = new Lazy<IArticleRepository>(() => new
                ArticleRepository(repositoryContext));

            _categoryRepository = new Lazy<ICategoryRepository>(() => new
                CategoryRepository(repositoryContext));

            _tagRepository = new Lazy<ITagRepository>(() => new
                TagRepository(repositoryContext));
        }

        public IArticleRepository ArticleRepository => _articleRepository.Value;
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;
        public ITagRepository TagRepository => _tagRepository.Value;


        public async Task SaveAsync() => await  _repositoryContext.SaveChangesAsync();


    }
}
