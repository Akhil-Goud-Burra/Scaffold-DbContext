using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace crud.Models.RegistrationRequestDTO
{
    public class RegistrationRequestDTO
    {
        public string? UserName { get; set; }

        public string? Name { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
