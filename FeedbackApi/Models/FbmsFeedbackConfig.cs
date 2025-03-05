using System;
using System.Collections.Generic;

namespace FeedbackApi.Models;

public partial class FbmsFeedbackConfig
{
    public int Id { get; set; }

    public string BuId { get; set; } = null!;

    public int BranchId { get; set; }

    public string BuName { get; set; } = null!;

    public string? BuAddress { get; set; }

    public string? BuEmailId { get; set; }

    public string? BuContactNumber { get; set; }

    public byte[]? BuLogo { get; set; }

    public string? BuColorTheme { get; set; }

    public string? BuFontColor { get; set; }

    public byte[]? BuMainImage { get; set; }

    public byte[]? BuLastImage { get; set; }

    public string? FdBkPageTitle { get; set; }

    public string? FdBkPageSubTitle { get; set; }

    public string? FdBkPageDialog { get; set; }

    public string? FdBkPageLastNote { get; set; }
}
