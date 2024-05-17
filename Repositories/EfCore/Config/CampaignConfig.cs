using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Config
{
    internal class CampaignConfig : IEntityTypeConfiguration<Campaign>

    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasData(
                new Campaign { Id = 1, Title = "Kanpanya1", AdvertPrice = 300 ,StartDate= new DateTime(2023,01,01),EndDate=new DateTime(2024,01,01)},
                new Campaign { Id = 2, Title = "Kanpanya2", AdvertPrice = 400, StartDate = new DateTime(2022, 01, 01), EndDate = new DateTime(2024, 01, 01) },
                new Campaign { Id = 3, Title = "Kanpanya3", AdvertPrice = 200 , StartDate = new DateTime(2021, 01, 01), EndDate = new DateTime(2024, 01, 01) }
                );
        }
    }
}
