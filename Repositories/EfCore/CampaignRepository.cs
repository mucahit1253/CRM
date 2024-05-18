using Entities.Models;
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


        public async Task<IEnumerable<Campaign>> GetAllCampaingAsync(bool trackChanges) =>
           await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();


        public async Task<Campaign> GetOneCampaingByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public void UpdateOneCampaign(Campaign campaign) => Update(campaign);

    }
}
