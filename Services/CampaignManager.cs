using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CampaignManager : ICampaignService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public CampaignManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }



        public CampaignDto CreateOneCampaign(CampaignDtoForInsertion campaignDto)
        {
            var entity = _mapper.Map<Campaign>(campaignDto);
            _manager.Campaign.CreateOneCampaign(entity);
            _manager.Save();
            return _mapper.Map<CampaignDto>(entity);
        }

        public void DeleteOneCampaign(int id, bool trackChanhes)
        {
            var entity = _manager.Campaign.GetOneCampaingById(id, trackChanhes);
            if (entity is null)
                throw new CampaingNotFoundException(id);
               

            _manager.Campaign.DeleteOneCampaign(entity);
            _manager.Save();
        }

        public IEnumerable<CampaignDto> GetAllCampaign(bool trackChanhes)
        {
            var campaigns= _manager.Campaign.GetAllCampaing(trackChanhes);
            return _mapper.Map<IEnumerable<CampaignDto>>(campaigns);
        }

        public CampaignDto GetOneCampaignById(int id, bool trackChanhes)
        {
            var campaign= _manager.Campaign.GetOneCampaingById(id, trackChanhes);
            if (campaign is null)
                throw new CampaingNotFoundException(id);
            return _mapper.Map<CampaignDto>(campaign);
        }

        public (CampaignDtoForUpdate campaignDtoForUpdate, Campaign campaign) GetOneCampaignForPatch(int id, bool trackChanges)
        {
            var campaign = _manager.Campaign.GetOneCampaingById(id, trackChanges);
            if (campaign is null)
                throw new CampaingNotFoundException(id);
            var campaignDtoForUpdate=_mapper.Map<CampaignDtoForUpdate>(campaign);
            return (campaignDtoForUpdate,campaign);

        }

        public void SaveChangesForPatch(CampaignDtoForUpdate campaignDtoForUpdate, Campaign campaign)
        {
            _mapper.Map(campaignDtoForUpdate, campaign);
            _manager.Save();
        }

        public void UpdateOneCampaign(int id, 
            CampaignDtoForUpdate campaignDto,
            bool trackChanges)
        {
            var entity = _manager.Campaign.GetOneCampaingById(id, trackChanges);
            if (entity is null)
                throw new CampaingNotFoundException(id);

            //mapping
            entity = _mapper.Map<Campaign>(campaignDto);
            _manager.Campaign.Update(entity);
            _manager.Save();
        }
    }
}

