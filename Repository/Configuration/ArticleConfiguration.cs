using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {

       


        public void Configure(EntityTypeBuilder<Article> builder)
        {
            
            builder.HasData
            (
                new Article
                {
                    Id = new Guid("ab52df6b-5881-4e09-a4f6-959200b54376"),
                    Title = "TitleArticleOne",
                    Summary = "SummaryArticleOne",
                    CategoryId = new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03"),
                },
                new Article
                {
                    Id = new Guid("1f16a542-b836-4152-893c-a0884baf210c"),
                    Title = "TitleArticleOne",
                    Summary = "SummaryArticleOne",
                    CategoryId = new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03")
                },
                new Article
                {
                    Id = new Guid("eea19341-1122-4ba8-b94c-404348adcc00"),
                    Title = "TitleArticleOne",
                    Summary = "SummaryArticleOne",
                    CategoryId = new Guid("02a95519-a82b-4b57-8c51-05d261e27c05")
                },
                new Article
                {
                    Id = new Guid("d6bbcf6b-a935-46cc-9359-f52b6f2f11f1"),
                    Title = "TitleArticleOne",
                    Summary = "SummaryArticleOne",
                    CategoryId = new Guid("02a95519-a82b-4b57-8c51-05d261e27c05")
                },
                new Article
                {
                    Id = new Guid("bb296082-a5e4-4b5c-99e3-4595144be332"),
                    Title = "TitleArticleOne",
                    Summary = "SummaryArticleOne",
                    CategoryId = new Guid("02a95519-a82b-4b57-8c51-05d261e27c05")
                }
                
            );
        }
    }
}
