using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options): base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }


        public DbSet<Category>? Categories { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<Article>? Articles { get; set; }
        //public DbSet<ArticleTag>? ArticlesTag { get; set;}
    }
}
