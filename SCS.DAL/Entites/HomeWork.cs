using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class HomeWork
{
    public int HomeWorkId { get; set; }

    public int SubjectClassId { get; set; }

    public int TermId { get; set; }

    public decimal HomeWorkDegree { get; set; }

    public string HomeWorkTitle { get; set; } = null!;

    public string? HomeWorkdescription { get; set; }

    public string? HomeWorkText { get; set; }

    public string? HomeWorkFile { get; set; }

    public string? HomeWorkImage { get; set; }

    public DateOnly HomeWorkDate { get; set; }

    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();

    public virtual SubjectClass SubjectClass { get; set; } = null!;

    public virtual Term Term { get; set; } = null!;
}
