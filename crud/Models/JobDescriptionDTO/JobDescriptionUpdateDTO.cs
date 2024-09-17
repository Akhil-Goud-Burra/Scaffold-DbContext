using System.ComponentModel.DataAnnotations;

namespace crud.Models.JobDescriptionDTO
{
    public class JobDescriptionUpdateDTO
    {
        [Required]
        public int JobDescriptionId { get; set; }

        [Required]
        public string? JobTitle { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public string? EndDate { get; set; }


    }
}
