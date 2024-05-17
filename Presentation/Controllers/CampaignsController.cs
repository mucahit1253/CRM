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
        public IActionResult CreateOneCampaign([FromBody] CampaignDtoForInsertion campaignDto)
        {
            
            if (campaignDto is null)
                    return BadRequest();//400
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

               var campaign= _manager.CampaignService.CreateOneCampaign(campaignDto);

                return StatusCode(201, campaign);
            
            

                
            
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCampaign([FromRoute(Name = "id")] int id,
            [FromBody] CampaignDtoForUpdate campaignDto)
        {

            
            if (campaignDto is null)
                    return BadRequest();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            _manager.CampaignService.UpdateOneCampaign(id, campaignDto, false);

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
              [FromBody] JsonPatchDocument<CampaignDtoForUpdate> campaignPatch)
        {
            if (campaignPatch is null)
                return BadRequest();

            var result = _manager.CampaignService.GetOneCampaignForPatch(id, false);

            campaignPatch.ApplyTo(result.campaignDtoForUpdate,ModelState);

            TryValidateModel(result.campaignDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            _manager.CampaignService.SaveChangesForPatch(result.campaignDtoForUpdate, result.campaign);
            return NoContent();
           
        }

    }
}
