using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICampaignRepository :IRepositoriesBase<Campaign>
    {
        Task<PagedList<Campaign>> GetAllCampaingAsync(CampaignParameters campaignParameters, bool trackChanges);
        Task<Campaign> GetOneCampaingByIdAsync(int id, bool trackChanges);

        void CreateOneCampaign(Campaign campaign);
        void UpdateOneCampaign(Campaign campaign);
        void DeleteOneCampaign(Campaign campaign);
        Task<List<Campaign>> GetAllCampaignAsync(bool trackChanges);
    }
}
