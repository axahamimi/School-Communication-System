using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class TeacherAttendance
{
    public int TeacherAttendanceId { get; set; }

    public int UserId { get; set; }

    public decimal TeacherAttendanceValue { get; set; }

    public DateOnly TeacherAttendanceDate { get; set; }

    public virtual User User { get; set; } = null!;
}
