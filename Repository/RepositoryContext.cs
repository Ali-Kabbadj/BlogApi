using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {

        public RepositoryContext(DbContextOptions options): base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleTag>()
            .HasKey(e => new { e.TagId, e.ArticleId });

            modelBuilder.Entity<ArticleTag>()
            .HasOne<Article>(e => e.Acticle)
            .WithMany(p => p.ArticleTags);

            modelBuilder.Entity<ArticleTag>()
            .HasOne<Tag>(e => e.Tag)
            .WithMany(p => p.TagArticles);


            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleTagConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }


        public DbSet<Category>? Categories { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<Article>? Articles { get; set; }
        //public DbSet<ArticleTag>? ArticlesTag { get; set;}
    }
}
