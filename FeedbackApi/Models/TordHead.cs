using System;
using System.Collections.Generic;

namespace FeedbackApi.Models;

public partial class TordHead
{
    public long TordHdId { get; set; }

    public int? TordSeriesId { get; set; }

    public string? TordNo { get; set; }

    public DateTime? TordDate { get; set; }

    public string? RefNo { get; set; }

    public int? UserId { get; set; }

    public long? AccountId { get; set; }

    public string? CustName { get; set; }

    public string? MobNo { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public long? LandMarkId { get; set; }

    public string? Pincode { get; set; }

    public long? AreaId { get; set; }

    public decimal? NetAmt { get; set; }

    public decimal? OrdAmt { get; set; }

    public string? Inwords { get; set; }

    public string? Remarks { get; set; }

    public decimal? TaxAmt { get; set; }

    public decimal? VatAmt { get; set; }

    public decimal? Stamt { get; set; }

    public decimal? DiscPerc { get; set; }

    public decimal? DiscValue { get; set; }

    public long? DiscCodeId { get; set; }

    public decimal? AdordAmt { get; set; }

    public decimal? AdvatAmt { get; set; }

    public decimal? Adstamt { get; set; }

    public decimal? AdnetAmt { get; set; }

    public decimal? AdvPaid { get; set; }

    public decimal? TotalPaid { get; set; }

    public DateTime? DelDate { get; set; }

    public DateTime? TrialDate { get; set; }

    public string? IsClosed { get; set; }

    public long? CompanyId { get; set; }

    public long? OrderTypeId { get; set; }

    public byte[]? RefImage1 { get; set; }

    public byte[]? RefImage2 { get; set; }

    public byte[]? RefImage3 { get; set; }

    public int? AssSalesmanId { get; set; }

    public string? SalesmanName { get; set; }

    public DateTime? AssDate { get; set; }

    public bool? SmsignOff { get; set; }

    public DateTime? SmsignOffDate { get; set; }

    public decimal? Smcomm { get; set; }

    public long? BookPageNo { get; set; }

    public long? RefBillNo { get; set; }

    public decimal? RefBillAmt { get; set; }

    public int? RefBillCompId { get; set; }

    public bool? IsCancelled { get; set; }

    public string? CustRemarks { get; set; }

    public string? InternalRemarks { get; set; }

    public decimal? TotalFabAmt { get; set; }

    public long? AssForDelTo { get; set; }

    public string? Dmname { get; set; }

    public DateTime? AssForDelOn { get; set; }

    public bool? DelSignOff { get; set; }

    public DateTime? OrdDelOn { get; set; }

    public int? DelMode { get; set; }

    public int? BookingMode { get; set; }

    public string? DelRemarks { get; set; }

    public bool? FbsmsSent { get; set; }

    public string? DelAdd { get; set; }

    public string? DelPincode { get; set; }

    public long? DelAreaId { get; set; }

    public long? DelLandmarkId { get; set; }

    public DateTime? CallDate { get; set; }

    public DateTime? AppointmentDt { get; set; }

    public string? PrefferedTime { get; set; }

    public int? SeriesId { get; set; }

    public long? ItemId { get; set; }

    public string? DelPrefTime { get; set; }

    public string? OrderReady { get; set; }

    public string? OrdBarcode { get; set; }

    public long? AppointHeadId { get; set; }

    public long? FinYearId { get; set; }

    public string? OrderSeries { get; set; }

    public int? SeriesNo { get; set; }

    public long? BranchId { get; set; }

    public long? InstoreSid { get; set; }

    public string? PromoCode { get; set; }

    public long? FbId { get; set; }

    public long? Rating { get; set; }

    public string? SalesType { get; set; }

    public string? CustGstin { get; set; }

    public string? CalType { get; set; }

    public decimal? Tsgstamt { get; set; }

    public decimal? Tcgstamt { get; set; }

    public decimal? Tigstamt { get; set; }

    public decimal? FebDueAmt { get; set; }

    public decimal? PreDiscNetAmt { get; set; }

    public int? EventId { get; set; }

    public string? EventName { get; set; }

    public DateTime? EventDate { get; set; }

    public bool? IsUrgent { get; set; }

    public decimal? CashDiscount { get; set; }

    public string? TrackId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public int? IsPkgLabelPrinted { get; set; }

    public string? OrderUid { get; set; }

    public string? BuId { get; set; }

    public bool? GroupOrder { get; set; }

    public decimal? SalesManCommissionAmt { get; set; }

    public DateTime? SalesManCommissionPayDate { get; set; }

    public long? SalesManCommissionPayId { get; set; }

    public long? SalesManCommissionPayVouNo { get; set; }

    public DateTime? OrderBookedDate { get; set; }

    public int? OrderBookedBy { get; set; }

    public DateTime? OrderDispatchedToWorkshopDate { get; set; }

    public int? OrderDispatchedToWorkshopBy { get; set; }

    public DateTime? OrderProductionStartDate { get; set; }

    public int? OrderProductionStartedBy { get; set; }

    public DateTime? OrderProductionEndDate { get; set; }

    public int? OrderProductionCompletedBy { get; set; }

    public DateTime? OrderReadyDate { get; set; }

    public int? OrderReadyBy { get; set; }

    public DateTime? OrderDeliveredDate { get; set; }

    public int? OrderDeliveredBy { get; set; }

    public string? Feedback { get; set; }

    public DateTime? FeedbackReceivedOn { get; set; }

    public int? AvgRating { get; set; }

    public string? OverAllComment { get; set; }
}
