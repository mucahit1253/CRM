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



        public Campaign CreateOneCampaign(Campaign campaign)
        {
            _manager.Campaign.CreateOneCampaign(campaign);
            _manager.Save();
            return campaign;
        }

        public void DeleteOneCampaign(int id, bool trackChanhes)
        {
            var entity = _manager.Campaign.GetOneCampaingById(id, trackChanhes);
            if (entity is null)
                throw new CampaingNotFoundException(id);
               

            _manager.Campaign.DeleteOneCampaign(entity);
            _manager.Save();
        }

        public IEnumerable<Campaign> GetAllCampaign(bool trackChanhes)
        {
            return _manager.Campaign.GetAllCampaing(trackChanhes);
        }

        public Campaign GetOneCampaignById(int id, bool trackChanhes)
        {
            var campaign= _manager.Campaign.GetOneCampaingById(id, trackChanhes);
            if (campaign is null)
                throw new CampaingNotFoundException(id);
            return campaign;
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

