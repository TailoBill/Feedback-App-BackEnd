namespace FeedbackApi.Dtos
{
    public class OrderDetailsDto
    {
        public long TordHdId { get; set; }
        public string? TordNo { get; set; }
        public string? TordDate { get; set; }
        public string? CustName { get; set; }
        public string? MobNo { get; set; }
        public decimal? NetAmt { get; set; }
        public decimal? TotalPaid { get; set; }
        public string? SalesmanName { get; set; }
        public string? DeliveredOn { get; set; }
        public int FeedbackCompleted { get; set; }
        public string? FeedbackReceivedOn { get; set; }

    }
}
