using ApiNewSample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNewSample.EntityConfig
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Introduction)
                .HasMaxLength(500);

            builder.Property(c => c.Product)
                .HasMaxLength(100);

            builder.Property(c => c.Country)
                .HasMaxLength(50);

            builder.Property(c => c.Industry)
                .HasMaxLength(50);

            builder.HasData(
                new Company
                {
                    Id = 1,
                    Name = "Microsoft",
                    Introduction = "Great Company",
                    Country = "USA",
                    Industry = "Software",
                    Product = "Software"
                },
                new Company
                {
                    Id = 2,
                    Name = "Google",
                    Introduction = "Don't be evil",
                    Country = "USA",
                    Industry = "Internet",
                    Product = "Software"
                },
                new Company
                {
                    Id = 3,
                    Name = "Alipapa",
                    Introduction = "Fubao Company",
                    Country = "China",
                    Industry = "Internet",
                    Product = "Software"
                },
                new Company
                {
                    Id = 4,
                    Name = "Tencent",
                    Introduction = "From Shenzhen",
                    Country = "China",
                    Industry = "ECommerce",
                    Product = "Software"
                },
                new Company
                {
                    Id = 5,
                    Name = "Baidu",
                    Introduction = "From Beijing",
                    Country = "China",
                    Industry = "Internet",
                    Product = "Software"
                },
                new Company
                {
                    Id = 6,
                    Name = "Adobe",
                    Introduction = "Photoshop?",
                    Country = "USA",
                    Industry = "Software",
                    Product = "Software"
                },
                new Company
                {
                    Id = 7,
                    Name = "SpaceX",
                    Introduction = "Wow",
                    Country = "USA",
                    Industry = "Technology",
                    Product = "Rocket"
                },
                new Company
                {
                    Id = 8,
                    Name = "AC Milan",
                    Introduction = "Football Club",
                    Country = "Italy",
                    Industry = "Football",
                    Product = "Football Match"
                },
                new Company
                {
                    Id = 9,
                    Name = "Suning",
                    Introduction = "From Jiangsu",
                    Country = "China",
                    Industry = "ECommerce",
                    Product = "Goods"
                },
                new Company
                {
                    Id = 10,
                    Name = "Twitter",
                    Introduction = "Blocked",
                    Country = "USA",
                    Industry = "Internet",
                    Product = "Tweets"
                },
                new Company
                {
                    Id = 11,
                    Name = "Youtube",
                    Introduction = "Blocked",
                    Country = "USA",
                    Industry = "Internet",
                    Product = "Videos"
                },
                new Company
                {
                    Id = 12,
                    Name = "360",
                    Introduction = "- -",
                    Country = "China",
                    Industry = "Security",
                    Product = "Security Product"
                },
                new Company
                {
                    Id = 13,
                    Name = "Jingdong",
                    Introduction = "Brothers",
                    Country = "China",
                    Industry = "ECommerce",
                    Product = "Goods"
                },
                new Company
                {
                    Id = 14,
                    Name = "NetEase",
                    Introduction = "Music?",
                    Country = "China",
                    Industry = "Internet",
                    Product = "Songs"
                },
                new Company
                {
                    Id = 15,
                    Name = "Amazon",
                    Introduction = "Store",
                    Country = "USA",
                    Industry = "ECommerce",
                    Product = "Books"
                },
                new Company
                {
                    Id = 16,
                    Name = "AOL",
                    Introduction = "Not Exists?",
                    Country = "USA",
                    Industry = "Internet",
                    Product = "Website"
                },
                new Company
                {
                    Id = 17,
                    Name = "Yahoo",
                    Introduction = "Who?",
                    Country = "USA",
                    Industry = "Internet",
                    Product = "Mail"
                },
                new Company
                {
                    Id = 18,
                    Name = "Firefox",
                    Introduction = "Is it a company?",
                    Country = "USA",
                    Industry = "Internet",
                    Product = "Browser"
                }
                );
        }
    }
}
