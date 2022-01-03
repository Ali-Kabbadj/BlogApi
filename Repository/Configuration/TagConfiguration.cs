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
    internal class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData
            (
                new Tag
                {
                    Id = new Guid("eee4a769-de0c-4e4d-9b4e-8f50406a5fac"),
                    TagValue = "left-politics"
                },
                new Tag
                {
                    Id = new Guid("0e617317-64c7-4e53-bf27-396d93c87c82"),
                    TagValue = "right-politics",
                },
                new Tag
                {
                    Id = new Guid("ce9f0204-8ded-4e5b-b044-328455f0c3f0"),
                    TagValue = "ecology"
                },
                new Tag
                {
                    Id = new Guid("0eea77a8-e163-4b52-b0dc-d67fd7eec682"),
                    TagValue = "Anxiety"
                },
                new Tag
                {
                    Id = new Guid("61191da9-4363-47ef-9745-996b9410dce4"),
                    TagValue = "phylosophy"
                },
                new Tag
                {
                    Id = new Guid("e7a6fd40-bde2-4b29-a9cd-de69093296ca"),
                    TagValue = "Boudism"
                },
                new Tag
                {
                    Id = new Guid("975f1f23-971f-45f0-bcf8-8a354e4e1cf9"),
                    TagValue = "Personal"
                }
            );
        }
    }
}
