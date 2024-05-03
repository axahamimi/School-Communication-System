using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class VteacherEvalution
{
    public string TeacherName { get; set; } = null!;

    public decimal TeacherEvaluationValue { get; set; }

    public decimal TeacherEvaluationValueTow { get; set; }
}
