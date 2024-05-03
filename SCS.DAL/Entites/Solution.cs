using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class Solution
{
    public int SolutionId { get; set; }

    public int HomeWorkId { get; set; }

    public int StudentId { get; set; }

    public string? SolutionImage { get; set; }

    public string? SolutionFile { get; set; }

    public DateOnly SolutionDate { get; set; }

    public decimal? SolutionDegree { get; set; }

    public string? Solutionnote { get; set; }

    public virtual HomeWork HomeWork { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
