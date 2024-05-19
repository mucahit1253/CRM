namespace Entities.RequestFeatures
{
    public class CampaignParameters : RequestParameters
    {
        // tarihe göre fitreleme
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.Now;
        public bool ValidDateRange => EndDate > StartDate;

        public String? SearchTerm { get; set; }

        public CampaignParameters()
        {
            OrderBy = "id";
        }
    }
  
}
