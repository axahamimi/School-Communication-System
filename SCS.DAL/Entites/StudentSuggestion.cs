using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class StudentSuggestion
{
    public int StudentSuggestionId { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public string? StudentSuggestionText { get; set; }

    public string? StudentSuggestionImage { get; set; }

    public DateOnly? StudentSuggestionDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
