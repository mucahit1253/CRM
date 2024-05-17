using Entities.Models;
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


        public IQueryable<Campaign> GetAllCampaing(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Id);


        public Campaign GetOneCampaingById(int id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefault();


        public void UpdateOneCampaign(Campaign campaign) => Update(campaign);

    }
}
