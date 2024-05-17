using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Config
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICampaignRepository> _campaignRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _campaignRepository = new Lazy<ICampaignRepository>(() => new CampaignRepository(_context));
        }

        public ICampaignRepository Campaign => _campaignRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
