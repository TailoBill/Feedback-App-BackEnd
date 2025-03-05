using System;
using System.Collections.Generic;

namespace FeedbackApi.Models;

public partial class FbmsFeedbackQuestion
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public bool IsMandatory { get; set; }

    public string Score1Feeling { get; set; } = null!;

    public string Score1FollowUpQuestion { get; set; } = null!;

    public string Score1DisplayMessage { get; set; } = null!;

    public string Score2Feeling { get; set; } = null!;

    public string Score2FollowUpQuestion { get; set; } = null!;

    public string Score2DisplayMessage { get; set; } = null!;

    public string Score3Feeling { get; set; } = null!;

    public string Score3FollowUpQuestion { get; set; } = null!;

    public string Score3DisplayMessage { get; set; } = null!;

    public string Score4Feeling { get; set; } = null!;

    public string Score4FollowUpQuestion { get; set; } = null!;

    public string Score4DisplayMessage { get; set; } = null!;

    public string Score5Feeling { get; set; } = null!;

    public string Score5FollowUpQuestion { get; set; } = null!;

    public string Score5DisplayMessage { get; set; } = null!;

    public long CompanyId { get; set; }

    public long BranchId { get; set; }

    public string? QuestionType { get; set; }
}
