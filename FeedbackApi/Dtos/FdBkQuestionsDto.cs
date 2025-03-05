using FeedbackApi.Models;

namespace FeedbackApi.Dtos
{
    public class FdBkQuestionsDto
    {
        public int SerialNo { get; set; } // PascalCase for consistency

        public int Id { get; set; }
        public string? Question { get; set; }
        public bool IsMandatory { get; set; }

        public string? Score1Feeling { get; set; }
        public string? Score1FollowUpQuestion { get; set; }
        public string? Score1DisplayMessage { get; set; }

        public string? Score2Feeling { get; set; }
        public string? Score2FollowUpQuestion { get; set; }
        public string? Score2DisplayMessage { get; set; }

        public string? Score3Feeling { get; set; }
        public string? Score3FollowUpQuestion { get; set; }
        public string? Score3DisplayMessage { get; set; }

        public string? Score4Feeling { get; set; }
        public string? Score4FollowUpQuestion { get; set; }
        public string? Score4DisplayMessage { get; set; }

        public string? Score5Feeling { get; set; }
        public string? Score5FollowUpQuestion { get; set; }
        public string? Score5DisplayMessage { get; set; }

        public int BranchID { get; set; }
        public string? QuestionType { get; set; }

        // Constructor for Mapping Entity to DTO
        public FdBkQuestionsDto(FbmsFeedbackQuestion entity)
        {
            Id = (int)entity.Id;
            Question = entity.Question;
            IsMandatory = entity.IsMandatory;

            Score1Feeling = entity.Score1Feeling;
            Score1FollowUpQuestion = entity.Score1FollowUpQuestion;
            Score1DisplayMessage = entity.Score1DisplayMessage;

            Score2Feeling = entity.Score2Feeling;
            Score2FollowUpQuestion = entity.Score2FollowUpQuestion;
            Score2DisplayMessage = entity.Score2DisplayMessage;

            Score3Feeling = entity.Score3Feeling;
            Score3FollowUpQuestion = entity.Score3FollowUpQuestion;
            Score3DisplayMessage = entity.Score3DisplayMessage;

            Score4Feeling = entity.Score4Feeling;
            Score4FollowUpQuestion = entity.Score4FollowUpQuestion;
            Score4DisplayMessage = entity.Score4DisplayMessage;

            Score5Feeling = entity.Score5Feeling;
            Score5FollowUpQuestion = entity.Score5FollowUpQuestion;
            Score5DisplayMessage = entity.Score5DisplayMessage;

            BranchID = (int)entity.BranchId;
            //QuestionType = entity.QuestionType;
        }
    }
}
