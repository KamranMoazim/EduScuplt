

using System.ComponentModel.DataAnnotations;

namespace Backend.Models.HelpingModels
{
    public class Identity
    {
        [Key]
        public long ID { get; set; }
    }
}