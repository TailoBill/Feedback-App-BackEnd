using FeedbackApi.Utils;


using System.Text.Json.Serialization; // ✅ Use System.Text.Json for serialization

namespace FeedbackApi.Dtos
{
    public class OrderUpdateDto
    {
        [JsonPropertyName("avg_rating")] // ✅ Ensure snake_case naming
        public int? AvgRating { get; set; }

        [JsonPropertyName("overall_comment")]
        public string? OverallComment { get; set; }

        [JsonPropertyName("feedback_received_on")]
        public DateTime? FeedbackReceivedOn { get; set; }

        [JsonPropertyName("feedback")]
        public string Feedback { get; set; } = string.Empty;  // Avoid null issues
    }
}

