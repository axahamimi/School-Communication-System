using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class StudentQeustion
{
    public int StudentQeustionId { get; set; }

    public int SubjectClassId { get; set; }

    public int StudentId { get; set; }

    public int TermId { get; set; }

    public string? StudentQeustionText { get; set; }

    public string? StudentQeustionImage { get; set; }

    public DateOnly StudentQeustionDate { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual SubjectClass SubjectClass { get; set; } = null!;

    public virtual ICollection<TeacherAnswer> TeacherAnswers { get; set; } = new List<TeacherAnswer>();

    public virtual Term Term { get; set; } = null!;
}
