using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym_Management.Models
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<TokenInfo> TokenInfo { get; set; }
        public DbSet<TrainersDetails> TrainersDetails { get; set;}
        public DbSet<AppointmentDetails> AppointmentsDetails { get; set;}
    }
}
