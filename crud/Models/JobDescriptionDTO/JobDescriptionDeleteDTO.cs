using System.ComponentModel.DataAnnotations;

namespace crud.Models.JobDescriptionDTO
{
    public class JobDescriptionDeleteDTO
    {
        [Required]
        public int JobDescriptionId { get; set; }
    }
}
