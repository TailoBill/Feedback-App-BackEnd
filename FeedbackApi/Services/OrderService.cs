using FeedbackApi.Dtos;
using FeedbackApi.Exceptions;
using FeedbackApi.Models;
using System.Linq;

namespace FeedbackApi.Services
{
    public class OrderService
    {
        private readonly FeedbackDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly FdBkConfigService _fdBkConfigService;

        public OrderService(FeedbackDbContext context, IConfiguration configuration, FdBkConfigService fdBkConfigService)
        {
            _context = context;
            _configuration = configuration;
            _fdBkConfigService = fdBkConfigService;
        }

        public OrderDetailsDto GetOrder(string id)
        {
            var order = _context.TordHeads
                .Where(c => c.OrderUid == id)
                .Select(c => new OrderDetailsDto
                {
                    TordHdId = c.TordHdId,
                    TordNo = c.TordNo,
                    TordDate = c.TordDate.HasValue
        ? c.TordDate.Value.ToString("yyyy-MM-dd")
        : null,
                    CustName = c.CustName,
                    MobNo = c.MobNo,
                    NetAmt = c.NetAmt,
                    TotalPaid = c.TotalPaid,
                    SalesmanName = c.SalesmanName,
                })
                .FirstOrDefault();

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {id} not found.");
            }

            return order;
        }

        public void Update(int TordHdId, OrderUpdateDto orderUpdateDto)
        {
            TordHead ordHead = _context.TordHeads.Where(c => c.TordHdId == TordHdId).FirstOrDefault();
            if (ordHead == null)
            {
                throw new HttpResponseException(404, string.Format("No TordHd with ID = {0}", TordHdId));
            }
            ordHead.Feedback = orderUpdateDto.Feedback;
            ordHead.FeedbackReceivedOn = orderUpdateDto.FeedbackReceivedOn;
            ordHead.AvgRating = orderUpdateDto.AvgRating;
            ordHead.OverAllComment = orderUpdateDto.OverallComment;
            _context.TordHeads.Update(ordHead);
            _context.SaveChanges();
        }

        public void SaveFeedback(long tordHdId, OrderUpdateDto orderUpdateDto)
        {

            Console.WriteLine($"Received Feedback for Order {tordHdId}:");
            Console.WriteLine($"AvgRating: {orderUpdateDto.AvgRating}");
            Console.WriteLine($"OverallComment: {orderUpdateDto.OverallComment}");
            Console.WriteLine($"FeedbackReceivedOn: {orderUpdateDto.FeedbackReceivedOn}");
            Console.WriteLine($"Feedback: {orderUpdateDto.Feedback}");


            var tordHead = _context.TordHeads.FirstOrDefault(o => o.TordHdId == tordHdId);
            if (tordHead == null)
            {
                throw new KeyNotFoundException($"Order with ID {tordHdId} not found.");
            }

            // Update fields in TordHead
            tordHead.Feedback = orderUpdateDto.Feedback;  // JSON formatted feedback
            if (orderUpdateDto.AvgRating.HasValue)
                tordHead.AvgRating = orderUpdateDto.AvgRating;

            if (!string.IsNullOrEmpty(orderUpdateDto.OverallComment))
                tordHead.OverAllComment = orderUpdateDto.OverallComment;

            if (orderUpdateDto.FeedbackReceivedOn.HasValue)
                tordHead.FeedbackReceivedOn = orderUpdateDto.FeedbackReceivedOn;

            //tordHead.FeedbackReceivedOn = orderUpdateDto.FeedbackReceivedOn ?? DateTime.Now;  // Use current date if null
            //tordHead.AvgRating = orderUpdateDto.AvgRating;
            //tordHead.OverAllComment = orderUpdateDto.OverallComment;
            _context.TordHeads.Update(tordHead);
            _context.SaveChanges();
        }

        public FdBkConfigAndOrderDto GetOrderDetails(string orderId)
        {

            var order = _context.TordHeads
               .Where(c => c.OrderUid == orderId)
               .Select(c => new OrderDetailsDto
               {
                   TordHdId = c.TordHdId,
                   TordNo = c.TordNo,
                   TordDate = c.TordDate.HasValue ? c.TordDate.Value.ToString("yyyy-MM-dd") : null,
                   CustName = c.CustName,
                   MobNo = c.MobNo,
                   NetAmt = c.NetAmt,
                   TotalPaid = c.TotalPaid,
                   SalesmanName = c.SalesmanName,
                   DeliveredOn = c.OrdDelOn.HasValue ? c.OrdDelOn.Value.ToString("yyyy-MM-dd") : null,
                   // ✅ Check if feedback is already given
                    FeedbackCompleted = string.IsNullOrEmpty(c.Feedback) ? 0 : 1,

                   // ✅ Send feedback received date if exists
                   FeedbackReceivedOn = c.FeedbackReceivedOn.HasValue ? c.FeedbackReceivedOn.Value.ToString("yyyy-MM-dd HH:mm:ss") : null
               })
               .FirstOrDefault();

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }


            //Fetch BU_ID
            var BusinessUnit = _context.TordHeads.SingleOrDefault(c => c.OrderUid == orderId);
            if (BusinessUnit == null)
            {
                throw new KeyNotFoundException($"No order found with ID = {orderId}");
            }

            // Fetch configuration
            var fdBkConfig = _context.FbmsFeedbackConfigs.SingleOrDefault(c => c.BranchId == BusinessUnit.BranchId);
            if (fdBkConfig == null)
            {
                throw new KeyNotFoundException($"No fdBkConfig found with ID = {BusinessUnit.BuId}");
            }

            // Fetch and transform questions
            var fdBkQuestions = _context.FbmsFeedbackQuestions
                .Where(c => c.BranchId == fdBkConfig.BranchId)
                .ToList();

            var fdBkQuestionsDtos = fdBkQuestions
    .Select((q, index) =>
    {
        var dto = new FdBkQuestionsDto(q);
        dto.SerialNo = index + 1; // Start from 1
        return dto;
    })
    .ToList();

            // If no questions found, add a default question
            if (!fdBkQuestionsDtos.Any())
            {
                fdBkQuestionsDtos.Add(GetDefaultQuestion(fdBkConfig.BranchId));
            }

            // Return DTO
            return new FdBkConfigAndOrderDto
            {
                FbdkConfig = _fdBkConfigService.toFdBkConfigDto(fdBkConfig),
                Order = order,
                Questions = fdBkQuestionsDtos
            };
        }

        private FdBkQuestionsDto GetDefaultQuestion(int BranchId)
        {
            var questionDto = new FdBkQuestionsDto(new FbmsFeedbackQuestion
            {

                Id = 1,  // Default ID
                Question = "How was your experience?",  // Default question text
                IsMandatory = true,

                Score1Feeling = "Very Bad",
                Score1FollowUpQuestion = "What went wrong?",
                Score1DisplayMessage = "We're truly sorry to hear that. Your feedback is valuable, and we’d love to know how we can improve your experience.",

                Score2Feeling = "Bad",
                Score2FollowUpQuestion = "What could be improved?",
                Score2DisplayMessage = "We regret that we didn’t meet your expectations. Please let us know how we can do better next time.",

                Score3Feeling = "Neutral",
                Score3FollowUpQuestion = "Any suggestions?",
                Score3DisplayMessage = "Thanks for your input! We appreciate your honest opinion and would love to hear any suggestions for improvement.",

                Score4Feeling = "Good",
                Score4FollowUpQuestion = "What did you like?",
                Score4DisplayMessage = "Glad to hear that! We’re always striving to do better, and we appreciate your positive feedback.",

                Score5Feeling = "Excellent",
                Score5FollowUpQuestion = "What was the best part?",
                Score5DisplayMessage = "That’s wonderful to hear! Thank you for your support – we’re thrilled that you had such a great experience!",

                BranchId = BranchId
            });

            // ✅ Assign `serialno = 1` explicitly
            questionDto.SerialNo = 1;
            questionDto.QuestionType = "emoji";

            return questionDto;
        }


    }
}
