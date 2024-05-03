using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class Subject
{
    public int SubjectId { get; set; }

    public int LevelId { get; set; }

    public string SubjectName { get; set; } = null!;

    public string? SubjectBook1 { get; set; }

    public string? SubjectBook2 { get; set; }

    public string? SubjectBook3 { get; set; }

    public virtual Level Level { get; set; } = null!;

    public virtual ICollection<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();
}
