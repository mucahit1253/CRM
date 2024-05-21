using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authencationService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager,
            ICampaignLinks campaignLinks)
        {
            _campaignService = new Lazy<ICampaignService>(() => 
            new CampaignManager(repositoryManager, logger, mapper,campaignLinks));

            _authencationService = new Lazy<IAuthenticationService>(() =>
           new AuthenticationManager(userManager, mapper, logger,configuration));
        }
        public ICampaignService CampaignService => _campaignService.Value;

        public IAuthenticationService AuthenticationService =>_authencationService.Value;
    }
}
