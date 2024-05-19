using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace WebApi.Utilities.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(CampaignDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<CampaignDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        private static void FormatCsv(StringBuilder buffer, CampaignDto campaign)
        {
            buffer.AppendLine($"{campaign.Id}, {campaign.Title}, {campaign.AdvertPrice},{campaign.StartDate},{campaign.EndDate}");
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<CampaignDto>)
            {
                foreach (var campaign in (IEnumerable<CampaignDto>)context.Object)
                {
                    FormatCsv(buffer, campaign);
                }
            }
            else
            {
                FormatCsv(buffer, (CampaignDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
    }
}