using System.ComponentModel.DataAnnotations;

namespace crud.Models.EmoloyeeModelDTO
{
    public class EmployeeUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }
    }
}
