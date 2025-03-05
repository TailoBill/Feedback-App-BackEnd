using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Models;

public partial class FeedbackDbContext : DbContext
{
    public FeedbackDbContext()
    {
    }

    public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FbmsFeedbackConfig> FbmsFeedbackConfigs { get; set; }

    public virtual DbSet<FbmsFeedbackQuestion> FbmsFeedbackQuestions { get; set; }

    public virtual DbSet<TordHead> TordHeads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FbmsFeedbackConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FBMS_Fee__3214EC27F4A28B96");

            entity.ToTable("FBMS_FeedbackConfig");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.BuAddress)
                .IsUnicode(false)
                .HasColumnName("BU_Address");
            entity.Property(e => e.BuColorTheme)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BU_ColorTheme");
            entity.Property(e => e.BuContactNumber)
                .IsUnicode(false)
                .HasColumnName("BU_Contact_Number");
            entity.Property(e => e.BuEmailId)
                .IsUnicode(false)
                .HasColumnName("BU_Email_Id");
            entity.Property(e => e.BuFontColor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BU_FontColor");
            entity.Property(e => e.BuId)
                .IsUnicode(false)
                .HasColumnName("BU_ID");
            entity.Property(e => e.BuLastImage)
                .HasColumnType("image")
                .HasColumnName("BU_LastImage");
            entity.Property(e => e.BuLogo)
                .HasColumnType("image")
                .HasColumnName("BU_Logo");
            entity.Property(e => e.BuMainImage)
                .HasColumnType("image")
                .HasColumnName("BU_MainImage");
            entity.Property(e => e.BuName)
                .IsUnicode(false)
                .HasColumnName("BU_Name");
            entity.Property(e => e.FdBkPageDialog)
                .IsUnicode(false)
                .HasColumnName("FdBk_Page_Dialog");
            entity.Property(e => e.FdBkPageLastNote)
                .IsUnicode(false)
                .HasColumnName("FdBk_Page_LastNote");
            entity.Property(e => e.FdBkPageSubTitle)
                .IsUnicode(false)
                .HasColumnName("FdBk_Page_SubTitle");
            entity.Property(e => e.FdBkPageTitle)
                .IsUnicode(false)
                .HasColumnName("FdBk_Page_Title");
        });

        modelBuilder.Entity<FbmsFeedbackQuestion>(entity =>
        {
            entity.ToTable("FBMS_FeedbackQuestions");

            entity.Property(e => e.Question).IsUnicode(false);
            entity.Property(e => e.QuestionType)
                .IsUnicode(false)
                .HasColumnName("Question_Type");
            entity.Property(e => e.Score1DisplayMessage)
                .IsUnicode(false)
                .HasColumnName("Score_1_Display_Message");
            entity.Property(e => e.Score1Feeling)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Score_1_Feeling");
            entity.Property(e => e.Score1FollowUpQuestion)
                .IsUnicode(false)
                .HasColumnName("Score_1_FollowUp_Question");
            entity.Property(e => e.Score2DisplayMessage)
                .IsUnicode(false)
                .HasColumnName("Score_2_Display_Message");
            entity.Property(e => e.Score2Feeling)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Score_2_Feeling");
            entity.Property(e => e.Score2FollowUpQuestion)
                .IsUnicode(false)
                .HasColumnName("Score_2_FollowUp_Question");
            entity.Property(e => e.Score3DisplayMessage)
                .IsUnicode(false)
                .HasColumnName("Score_3_Display_Message");
            entity.Property(e => e.Score3Feeling)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Score_3_Feeling");
            entity.Property(e => e.Score3FollowUpQuestion)
                .IsUnicode(false)
                .HasColumnName("Score_3_FollowUp_Question");
            entity.Property(e => e.Score4DisplayMessage)
                .IsUnicode(false)
                .HasColumnName("Score_4_Display_Message");
            entity.Property(e => e.Score4Feeling)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Score_4_Feeling");
            entity.Property(e => e.Score4FollowUpQuestion)
                .IsUnicode(false)
                .HasColumnName("Score_4_FollowUp_Question");
            entity.Property(e => e.Score5DisplayMessage)
                .IsUnicode(false)
                .HasColumnName("Score_5_Display_Message");
            entity.Property(e => e.Score5Feeling)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Score_5_Feeling");
            entity.Property(e => e.Score5FollowUpQuestion)
                .IsUnicode(false)
                .HasColumnName("Score_5_FollowUp_Question");
        });

        modelBuilder.Entity<TordHead>(entity =>
        {
            entity.HasKey(e => e.TordHdId);

            entity.ToTable("TOrdHead", tb => tb.HasTrigger("TorDHead_UPDATE"));

            entity.HasIndex(e => e.AccountId, "IX_TOrdHead_AccountId");

            entity.HasIndex(e => e.IsClosed, "IX_TOrdHead_IsClosed");

            entity.Property(e => e.TordHdId).HasColumnName("TOrdHdID");
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.AdnetAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ADNetAmt");
            entity.Property(e => e.AdordAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ADOrdAmt");
            entity.Property(e => e.Adstamt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ADSTAmt");
            entity.Property(e => e.AdvPaid)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdvatAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ADVatAmt");
            entity.Property(e => e.AppointHeadId).HasColumnName("AppointHeadID");
            entity.Property(e => e.AppointmentDt).HasColumnType("date");
            entity.Property(e => e.AssDate).HasColumnType("date");
            entity.Property(e => e.AssForDelOn).HasColumnType("date");
            entity.Property(e => e.AvgRating).HasColumnName("Avg_Rating");
            entity.Property(e => e.BuId)
                .IsUnicode(false)
                .HasColumnName("BU_ID");
            entity.Property(e => e.CalType).IsUnicode(false);
            entity.Property(e => e.CallDate).HasColumnType("date");
            entity.Property(e => e.CashDiscount)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustGstin)
                .IsUnicode(false)
                .HasColumnName("CustGSTIN");
            entity.Property(e => e.CustName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustRemarks).IsUnicode(false);
            entity.Property(e => e.DelAdd).IsUnicode(false);
            entity.Property(e => e.DelDate).HasColumnType("date");
            entity.Property(e => e.DelPincode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.DelPrefTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DelRemarks).IsUnicode(false);
            entity.Property(e => e.DiscPerc)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscValue)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Dmname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DMName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EventDate).HasColumnType("date");
            entity.Property(e => e.EventName).HasMaxLength(100);
            entity.Property(e => e.FbId).HasColumnName("FbID");
            entity.Property(e => e.FbsmsSent).HasColumnName("FBsmsSent");
            entity.Property(e => e.FebDueAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FeedbackReceivedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FinYearId).HasColumnName("FinYearID");
            entity.Property(e => e.InstoreSid).HasColumnName("InstoreSID");
            entity.Property(e => e.InternalRemarks).IsUnicode(false);
            entity.Property(e => e.Inwords)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsClosed)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsPkgLabelPrinted).HasColumnName("Is_Pkg_Label_Printed");
            entity.Property(e => e.LandMarkId).HasColumnName("LandMarkID");
            entity.Property(e => e.MobNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NetAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrdAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrdBarcode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrdDelOn).HasColumnType("date");
            entity.Property(e => e.OrderBookedDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDeliveredDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDispatchedToWorkshopDate).HasColumnType("datetime");
            entity.Property(e => e.OrderProductionEndDate).HasColumnType("datetime");
            entity.Property(e => e.OrderProductionStartDate).HasColumnType("datetime");
            entity.Property(e => e.OrderReady)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OrderReadyDate).HasColumnType("datetime");
            entity.Property(e => e.OrderSeries)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderUid)
                .IsUnicode(false)
                .HasColumnName("OrderUID");
            entity.Property(e => e.OverAllComment).HasColumnName("OverAll_Comment");
            entity.Property(e => e.Pincode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PreDiscNetAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrefferedTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PromoCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.RefBillAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RefImage1).HasColumnType("image");
            entity.Property(e => e.RefImage2).HasColumnType("image");
            entity.Property(e => e.RefImage3).HasColumnType("image");
            entity.Property(e => e.RefNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.SalesManCommissionAmt).HasColumnType("money");
            entity.Property(e => e.SalesManCommissionPayDate).HasColumnType("date");
            entity.Property(e => e.SalesType).IsUnicode(false);
            entity.Property(e => e.SalesmanName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Smcomm)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SMComm");
            entity.Property(e => e.SmsignOff).HasColumnName("SMSignOff");
            entity.Property(e => e.SmsignOffDate)
                .HasColumnType("date")
                .HasColumnName("SMSignOffDate");
            entity.Property(e => e.Stamt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("STAmt");
            entity.Property(e => e.TaxAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tcgstamt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TCGSTAmt");
            entity.Property(e => e.Tigstamt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TIGSTAmt");
            entity.Property(e => e.TordDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("TOrdDate");
            entity.Property(e => e.TordNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TOrdNo");
            entity.Property(e => e.TordSeriesId).HasColumnName("TOrdSeriesId");
            entity.Property(e => e.TotalFabAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrackId).HasColumnName("TrackID");
            entity.Property(e => e.TrialDate).HasColumnType("date");
            entity.Property(e => e.Tsgstamt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TSGSTAmt");
            entity.Property(e => e.VatAmt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
