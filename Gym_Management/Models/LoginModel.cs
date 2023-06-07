using System.ComponentModel.DataAnnotations;

namespace Gym_Management.Models
{
    public class LoginModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
