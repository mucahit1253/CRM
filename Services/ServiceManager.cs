using AutoMapper;
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
            IMapper mapper)
        {
            _campaignService = new Lazy<ICampaignService>(() => 
            new CampaignManager(repositoryManager,logger,mapper));
        }
        public ICampaignService CampaignService => _campaignService.Value;
    }
}
