using System.ComponentModel.DataAnnotations;

namespace Apbd5.Models
{
    public class Reservation
    {
        
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        [MinLength(1)]
        public string OrganizerName { get; set; } = String.Empty;

        [Required]
        [MinLength(1)]
        public string Topic { get; set; } = String.Empty;

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        [TimeBefore(nameof(EndTime))]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public string Status { get; set; } = String.Empty;
    }
}
