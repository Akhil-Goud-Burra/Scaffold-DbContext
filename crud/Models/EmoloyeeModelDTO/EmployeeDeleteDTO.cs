using System.ComponentModel.DataAnnotations;

namespace crud.Models.EmoloyeeModelDTO
{
    public class EmployeeDeleteDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
