using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crud.Models;

[Table("JobDescription")]
public partial class JobDescription
{
    [Key]
    public int JobDescriptionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? JobTitle { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EndDate { get; set; }

    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("JobDescriptions")]
    public virtual EmployeeTable? Employee { get; set; }
}
