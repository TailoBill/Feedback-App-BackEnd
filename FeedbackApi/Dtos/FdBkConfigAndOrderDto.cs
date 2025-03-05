using FeedbackApi.Models;

namespace FeedbackApi.Dtos
{
    public class FdBkConfigAndOrderDto
    {
        public FdBkConfigDto? FbdkConfig { get; set; }
        public OrderDetailsDto? Order { get; set; }

        public List<FdBkQuestionsDto>? Questions { get; set; }
    }
}
