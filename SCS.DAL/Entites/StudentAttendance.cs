using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class StudentAttendance
{
    public int StudentAttendanceId { get; set; }

    public int StudentId { get; set; }

    public int TermId { get; set; }

    public decimal StudentAttendanceValue { get; set; }

    public DateOnly StudentAttendanceDate { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Term Term { get; set; } = null!;
}
