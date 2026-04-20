using System.ComponentModel.DataAnnotations;

namespace Apbd5.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; } = String.Empty;

        [Required]
        [MinLength(1)]
        public string BuildingCode { get; set; } = String.Empty;

        [Required]
        public int Floor { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Capacity must be a positive Integer.")]
        public int Capacity { get; set; }

        [Required]
        public bool HasProjector { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
