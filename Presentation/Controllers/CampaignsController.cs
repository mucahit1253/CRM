using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Campaigns")]
    public class CampaignsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CampaignsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllCampaigns()
        {
            
                var campaigns = _manager.CampaignService.GetAllCampaign(false);
                return Ok(campaigns);
            
           
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneCampaign([FromRoute(Name = "id")] int id)
        {
                var campaign = _manager.CampaignService.GetOneCampaignById(id, false);

            
              return Ok(campaign);
            
            

        }

        [HttpPost]
        public IActionResult CreateOneCampaign([FromBody] Campaign campaign)
        {
            
                if (campaign is null)
                    return BadRequest();//400

                _manager.CampaignService.CreateOneCampaign(campaign);

                return StatusCode(201, campaign);
            
            

                
            
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCampaign([FromRoute(Name = "id")] int id,
            [FromBody] CampaignDtoForUpdate campaignDto)
        {

            
                if (campaignDto is null)
                    return BadRequest();
                _manager.CampaignService.UpdateOneCampaign(id, campaignDto, true);

                return NoContent();
          

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneCampaign([FromRoute(Name = "id")] int id)
        {

            _manager.CampaignService.DeleteOneCampaign(id, false);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallUpdateOneCampaign([FromRoute(Name = "id")] int id,
              [FromBody] JsonPatchDocument<Campaign> CampaignPatch)
        {
           
                //check Entitiy
                var entity = _manager
                    .CampaignService
                    .GetOneCampaignById(id, true);

                CampaignPatch.ApplyTo(entity);
                _manager.CampaignService.UpdateOneCampaign(id, 
                    new CampaignDtoForUpdate(entity.Id,entity.Title,entity.AdvertPrice,entity.StartDate,entity.EndDate),
                    true);
                return NoContent();
           
        }

    }
}
