using Microsoft.AspNetCore.Identity;

namespace Gym_Management.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
