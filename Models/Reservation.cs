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
        public String OrganizerName { get; set; } = String.Empty;

        [Required]
        [MinLength(1)]
        public String Topic { get; set; } = String.Empty;

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public String Status { get; set; } = String.Empty;

        public Reservation(int Id, int RoomId, String OrganizerName, String Topic, DateOnly Date, TimeOnly StartTime, TimeOnly EndTime, String status)
        {
            this.Id = Id;
            this.RoomId = RoomId;
            this.OrganizerName = OrganizerName;
            this.Topic = Topic;
            this.Date = Date;


        }

    }
}
