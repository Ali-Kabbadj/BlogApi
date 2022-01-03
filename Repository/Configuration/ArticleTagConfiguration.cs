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
    public class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTag>
    {
        public void Configure(EntityTypeBuilder<ArticleTag> builder)
        {

            builder.HasData
            (
                new ArticleTag
                {
                    TagId = new Guid("eee4a769-de0c-4e4d-9b4e-8f50406a5fac"),
                    ArticleId = new Guid("ab52df6b-5881-4e09-a4f6-959200b54376")
                },
                new ArticleTag
                {
                    TagId = new Guid("0e617317-64c7-4e53-bf27-396d93c87c82"),
                    ArticleId = new Guid("ab52df6b-5881-4e09-a4f6-959200b54376")
                },
                new ArticleTag
                {
                    TagId = new Guid("ce9f0204-8ded-4e5b-b044-328455f0c3f0"),
                    ArticleId = new Guid("ab52df6b-5881-4e09-a4f6-959200b54376")
                },
                new ArticleTag
                {
                    TagId = new Guid("0eea77a8-e163-4b52-b0dc-d67fd7eec682"),
                    ArticleId = new Guid("1f16a542-b836-4152-893c-a0884baf210c")
                },
                new ArticleTag
                {
                    TagId = new Guid("61191da9-4363-47ef-9745-996b9410dce4"),
                    ArticleId = new Guid("1f16a542-b836-4152-893c-a0884baf210c")
                },
                new ArticleTag
                {
                    TagId = new Guid("e7a6fd40-bde2-4b29-a9cd-de69093296ca"),
                    ArticleId = new Guid("1f16a542-b836-4152-893c-a0884baf210c")
                },
                new ArticleTag
                {
                    TagId = new Guid("975f1f23-971f-45f0-bcf8-8a354e4e1cf9"),
                    ArticleId = new Guid("1f16a542-b836-4152-893c-a0884baf210c")
                }
            );
        }
    }
}
