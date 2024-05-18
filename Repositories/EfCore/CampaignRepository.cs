using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class CampaignRepository : RepositoriesBase<Campaign>, ICampaignRepository
    {
        public CampaignRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCampaign(Campaign campaign) => Create(campaign);


        public void DeleteOneCampaign(Campaign campaign) => Delete(campaign);


        public async Task<PagedList<Campaign>> GetAllCampaingAsync(CampaignParameters campaignParameters,
            bool trackChanges)
        {
           var campaigns= await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();
            return PagedList<Campaign>
                .ToPagedList(campaigns, campaignParameters.PageNumber, campaignParameters.PageSize);
        }
           


        public async Task<Campaign> GetOneCampaingByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public void UpdateOneCampaign(Campaign campaign) => Update(campaign);

    }
}
