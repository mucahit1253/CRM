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
        public async Task <IActionResult> GetAllCampaignsAsync()
        {
            
                var campaigns =await _manager.CampaignService.GetAllCampaignAsync(false);
                return Ok(campaigns);
            
           
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCampaignAsync([FromRoute(Name = "id")] int id)
        {
                var campaign = await _manager.CampaignService.GetOneCampaignByIdAsync(id, false);

            
              return Ok(campaign);
            
            

        }

        [HttpPost]
        public async Task<IActionResult> CreateOneCampaignAsync([FromBody] CampaignDtoForInsertion campaignDto)
        {
            
            if (campaignDto is null)
                    return BadRequest();//400
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

               var campaign=await _manager.CampaignService.CreateOneCampaignAsync(campaignDto);

                return StatusCode(201, campaign);
            
            

                
            
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCampaignAsync([FromRoute(Name = "id")] int id,
            [FromBody] CampaignDtoForUpdate campaignDto)
        {

            
            if (campaignDto is null)
                    return BadRequest();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _manager.CampaignService.UpdateOneCampaignAsync(id, campaignDto, false);

                return NoContent();
          

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCampaignAsync([FromRoute(Name = "id")] int id)
        {

            await _manager.CampaignService.DeleteOneCampaignAsync(id, false);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task <IActionResult> PartiallUpdateOneCampaignAsync([FromRoute(Name = "id")] int id,
              [FromBody] JsonPatchDocument<CampaignDtoForUpdate> campaignPatch)
        {
            if (campaignPatch is null)
                return BadRequest();

            var result =await _manager.CampaignService.GetOneCampaignForPatchAsync(id, false);

            campaignPatch.ApplyTo(result.campaignDtoForUpdate,ModelState);

            TryValidateModel(result.campaignDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _manager.CampaignService.SaveChangesForPatchAsync(result.campaignDtoForUpdate, result.campaign);
            return NoContent();
           
        }

    }
}
