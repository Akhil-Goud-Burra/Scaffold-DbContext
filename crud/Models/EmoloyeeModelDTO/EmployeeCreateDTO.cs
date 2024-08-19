using System.ComponentModel.DataAnnotations;

namespace crud.Models.EmoloyeeModelDTO
{
    public class EmployeeCreateDTO 
    {
        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }
    }
}
