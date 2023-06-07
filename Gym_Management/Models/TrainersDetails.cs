using System.ComponentModel.DataAnnotations;

namespace Gym_Management.Models
{
    public class TrainersDetails
    {
        [Key]
        public int? TrainerId { get; set; }
        public string? TrainerName { get; set; }
        public int? Experiance { get; set; }
        public ICollection<AppointmentDetails> Appointments { get; set; } = new List<AppointmentDetails>();
    }
}
