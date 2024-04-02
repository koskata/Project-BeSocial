using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSocial.Data.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            List<Category> categories = new List<Category>()
            { 
                new Category()
                {
                    Id = 1,
                    Name = "Funny"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Lifestyle"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Sport"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Music"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Other"
                },
            };

            return categories.ToArray();
        }
    }
}
