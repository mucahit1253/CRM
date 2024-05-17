using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICampaignService
    {
        IEnumerable<CampaignDto> GetAllCampaign(bool trackChanhes);
        Campaign GetOneCampaignById(int id, bool trackChanhes);
        Campaign CreateOneCampaign(Campaign campaign);
        void UpdateOneCampaign(int id, CampaignDtoForUpdate campaignDto, bool trackChanges);
        void DeleteOneCampaign(int id, bool trackChanhes);

    }
}
