using System.ComponentModel.DataAnnotations;

namespace Gym_Management.Models
{
    public class AppointmentDetails
    {
        [Key]
        public int AppointmentId { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public TrainersDetails? Trainers { get; set; }
        public string? TrainingType { get; set; }
        public int? TrainingPeriod { get; set; }

    }
}
