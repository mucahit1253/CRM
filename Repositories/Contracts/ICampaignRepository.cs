using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICampaignRepository :IRepositoriesBase<Campaign>
    {
        IQueryable<Campaign> GetAllCampaing(bool trackChanges);
        Campaign GetOneCampaingById(int id, bool trackChanges);

        void CreateOneCampaign(Campaign campaign);
        void UpdateOneCampaign(Campaign campaign);
        void DeleteOneCampaign(Campaign campaign);
    }
}
