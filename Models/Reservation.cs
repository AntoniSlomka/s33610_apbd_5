using System.ComponentModel.DataAnnotations;

namespace Apbd5.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public String name { get; set; } = String.Empty;

        [Required]
        public int BuildingCode { get; set; }

        [Required]
        public int Floor { get; set; }

        public int Capacity { get; set; }


    }
}
