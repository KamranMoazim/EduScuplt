
using Backend.Dtos.UserDtos;

namespace Backend.Dtos.InstructorDtos
{
    public class InstructorDto
    {
        public int ID { get; set; }
        public string? AccountNo { get; set; }

        public string? AccountDetails { get; set; }
        public double PendingAmount { get; set; } = 0;
        public double WithdrawnAmount { get; set; } = 0;
        public double TotalEarnedAmount { get; set; } = 0;

        public UserDto User { get; set; }
    }
}