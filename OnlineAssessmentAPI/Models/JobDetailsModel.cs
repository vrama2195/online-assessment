using System;

namespace OnlineAssessmentAPI.Models;

public class JobDetailsModel
{
    public Guid? Id { get; set; }
        public string? RequestId { get; set; }
        public string? Description { get; set; }
        public string? RequestName { get; set; }
        public string? Requestor { get; set; }
        public string? ProjectCode { get; set; }
        public string? Client { get; set; }
        public string? LeadMarketArea { get; set; }
        public string? Opportunity { get; set; }
        public string? MarketHolder { get; set; }
        public string? AssessmentType { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string EmploymentType { get; set; } = "Full time";
        public DateTime CreatedDate { get; set; }
        public DateOnly ModifiedDate { get; set; }
        public string CreatedById { get; set; } = string.Empty;
        public string ModifiedById { get; set; } = string.Empty;
        public string Technology { get; set; } = string.Empty;
        public string SubTechnology { get; set; } = string.Empty;
        public List<HrCandidateDetailsModel> Candidates { get; set; } = new List<HrCandidateDetailsModel>();
        public string? Location { get; set; }



}
