
namespace Backend.Models
{
    public class Admin
    {
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}