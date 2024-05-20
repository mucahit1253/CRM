using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CampaignLinks:ICampaignLinks

    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<CampaignDto> _dataShaper;

        public CampaignLinks(LinkGenerator linkGenerator,
            IDataShaper<CampaignDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public LinkResponse TryGenerateLinks(IEnumerable<CampaignDto> campaignDto,
            string fields,
            HttpContext httpContext)
        {
            var shapedCampaign = ShapeData(campaignDto, fields);
            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkedCampaigns(campaignDto, fields, httpContext, shapedCampaign);
            return ReturnShapedCampaigns(shapedCampaign);
        }

        private LinkResponse ReturnLinkedCampaigns(IEnumerable<CampaignDto> campaignDto,
            string fields,
            HttpContext httpContext,
            List<Entity> shapedCampaign)
        {
            var campaignDtoList = campaignDto.ToList();

            for (int index = 0; index < campaignDtoList.Count(); index++)
            {
                var campaignLinks = CreateForcampaign(httpContext, campaignDtoList[index], fields);
                shapedCampaign[index].Add("Links", campaignLinks);
            }

            var campaignCollection = new LinkCollectionWrapper<Entity>(shapedCampaign);
            CreateForCampaigns(httpContext, campaignCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = campaignCollection };
        }

        private LinkCollectionWrapper<Entity> CreateForCampaigns(HttpContext httpContext,
            LinkCollectionWrapper<Entity> campaignCollectionWrapper)
        {
            campaignCollectionWrapper.Links.Add(new Link()
            {
                Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                Rel = "self",
                Method = "GET"
            });
            return campaignCollectionWrapper;
        }

        private List<Link> CreateForcampaign(HttpContext httpContext,
            CampaignDto campaignDto,
            string fields)
        {
            var links = new List<Link>()
            {
               new Link()
               {
                   Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}" +
                   $"/{campaignDto.Id}",
                   Rel = "self",
                   Method = "GET"
               },
               new Link()
               {
                   Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                   Rel="create",
                   Method = "POST"
               },
            };
            return links;
        }

        private LinkResponse ReturnShapedCampaigns(List<Entity> shapedCampaigns)
        {
            return new LinkResponse() { ShapedEntities = shapedCampaigns };
        }

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            ///klj
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType
                .SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private List<Entity> ShapeData(IEnumerable<CampaignDto> campaignsDto, string fields)
        {
            return _dataShaper
                .ShapeData(campaignsDto, fields)
                .Select(c => c.Entity)
                .ToList();
        }


    }
}
