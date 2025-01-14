﻿using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICampaignService
    {
        Task<(LinkResponse linkResponse, MetaData metaData)> GetAllCampaignAsync(LinkParameters linkParameters, bool trackChanhes);
        Task<CampaignDto> GetOneCampaignByIdAsync(int id, bool trackChanhes);
        Task<CampaignDto> CreateOneCampaignAsync(CampaignDtoForInsertion campaign);
        Task UpdateOneCampaignAsync(int id, CampaignDtoForUpdate campaignDto, bool trackChanges);
        Task DeleteOneCampaignAsync(int id, bool trackChanhes);
        Task<(CampaignDtoForUpdate campaignDtoForUpdate,Campaign campaign)>  GetOneCampaignForPatchAsync(int id, bool trackChanges);

        Task SaveChangesForPatchAsync(CampaignDtoForUpdate campaignDtoForUpdate, Campaign campaign);

    }
}
