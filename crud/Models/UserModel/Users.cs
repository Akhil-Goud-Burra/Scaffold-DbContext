using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace crud.Models.UserModel
{

    [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? UserName { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? Password { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? Role { get; set; }
    }
}
