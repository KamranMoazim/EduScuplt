

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.InstructorDtos
{
    public class ApproveInstructorDto
    {
        public int ID { get; set; }

        // Admin Related Properties
        public bool IsApproved { get; set; } = false;

        [Required(ErrorMessage = "Approved By - Admin Id is required.")]
        public int? ApprovedById { get; set; }
    }
}