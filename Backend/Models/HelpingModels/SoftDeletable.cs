

namespace Backend.Models.HelpingModels
{
    public class SoftDeletable : AuditInfo
    {
        public bool IsDeleted { get; set; } = false;
    }
}