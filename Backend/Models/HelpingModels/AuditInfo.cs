

namespace Backend.Models.HelpingModels
{
    public class AuditInfo : Identity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}