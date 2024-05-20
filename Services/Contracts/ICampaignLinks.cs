using Entities.DataTransferObjects;
using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Services.Contracts
{
    public interface ICampaignLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<CampaignDto> campaignsDto,
            string fields, HttpContext httpContext);
    }
}