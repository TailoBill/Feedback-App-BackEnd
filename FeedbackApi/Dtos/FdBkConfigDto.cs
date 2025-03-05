namespace FeedbackApi.Dtos
{
    public class FdBkConfigDto
    {
        public string? BU_ID { get; set; }
        public int BranchID { get; set; }
        public string? BU_Name { get; set; }
        public string? BU_Address { get; set; }
        public string? BU_Email_Id { get; set; }
        public string? BU_Contact_Number { get; set; }
        public string? BU_Logo_URL { get; set; }
        public string? BU_ColorTheme { get; set; }
        public string? bu_font_color { get; set; }
        public string? FdBk_Page_Title { get; set; }
        public string? FdBk_Page_SubTitle { get; set; }
        public string? FdBk_Page_Dialog { get; set; }
        public string? FdBk_Page_LastNote { get; set; }
        public string? BU_MainImg { get; set; }
        public string? BU_LastImg { get; set; }
    }
}
