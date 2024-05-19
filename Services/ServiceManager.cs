using AutoMapper;
using Entities.DataTransferObjects;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICampaignService> _campaignService;
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IDataShaper<CampaignDto> Shaper)
        {
            _campaignService = new Lazy<ICampaignService>(() => 
            new CampaignManager(repositoryManager,logger,mapper,Shaper));
        }
        public ICampaignService CampaignService => _campaignService.Value;
    }
}
