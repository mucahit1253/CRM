using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //[ApiVersion("2.0")]
    [ApiController]
    [Route("api/Campaigns")]
    public class CampaignsV2Controller:ControllerBase
    {
        private readonly IServiceManager _manager;

        public CampaignsV2Controller(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCampaignAsync()
        {
            var campaigns = await _manager.CampaignService.GetAllCampaignAsync(false);
            var campaignsv2 = campaigns.Select(c => new
            {
                Title = c.Title,
                Id = c.Id
            });
            return Ok(campaignsv2);
        }
    }
}
