using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineAssessmentAPI.Models;

public class HrCandidateDetailsModel
{
    [Key]
    public Guid? Id { get; set; }
    public string RequestId { get; set; } = string.Empty;
    public string CandidateName { get; set; } = string.Empty;
    public string Match { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string SkillMatch { get; set; } = string.Empty;
    public string ExperienceMatch { get; set; } = string.Empty;
    public bool IsChecked { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateOnly ModifiedDate { get; set; }
        public string CreatedById { get; set; } = string.Empty;
        public string ModifiedById { get; set; } = string.Empty;
}
