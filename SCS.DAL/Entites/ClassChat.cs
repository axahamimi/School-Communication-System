using System;
using System.Collections.Generic;

namespace SCS.DAL.Entites;

public partial class ClassChat
{
    public int ClassChatId { get; set; }

    public int Classid { get; set; }

    public int? StudentId { get; set; }

    public string ClassChatText { get; set; } = null!;

    public string? ClassChatImagePath { get; set; }

    public string? ClassChatFilePath { get; set; }

    public DateOnly ClassChatDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
