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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
                new Category
                {
                    Id = new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03"),
                    Name = "Politics"
                },
                new Category
                {
                    Id = new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"),
                    Name = "Physics"
                },
                new Category
                {
                    Id = new Guid("098d3a1e-f70d-445a-8487-72ca58fcc596"),
                    Name = "Health"
                },
                new Category
                {
                    Id = new Guid("3c723d99-f1a2-4ce8-965b-7b037c87f83e"),
                    Name = "Well-Being"
                },
                new Category
                {
                    Id = new Guid("d90aab27-c51d-46d6-8471-130e7390024a"),
                    Name = "Psycology"
                },
                new Category
                {
                    Id = new Guid("f473dafa-67a8-4f80-ba84-684a849965ba"),
                    Name = "Metaphyysics"
                }
            );
        }
    }
}
