using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crud.Models;

[Table("EmployeeTable")]
public partial class EmployeeTable
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Firstname { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Lastname { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<JobDescription> JobDescriptions { get; set; } = new List<JobDescription>();
}
