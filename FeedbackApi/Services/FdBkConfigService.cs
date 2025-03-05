using FeedbackApi.Dtos;
using FeedbackApi.Models;
using SixLabors.ImageSharp;
using System.Drawing;
using System.IO;

namespace FeedbackApi.Services
{

    public class FdBkConfigService
    {
        private readonly FeedbackDbContext _context;
        private readonly IConfiguration _configuration;

        public FdBkConfigService(FeedbackDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public ICollection<FdBkConfigDto> GetAll()
        {

            return _context.FbmsFeedbackConfigs.ToList().Select(x => toFdBkConfigDto(x)).ToList();
        }

        public FdBkConfigDto toFdBkConfigDto(FbmsFeedbackConfig fdBkConfig)
        {
            var dto = new FdBkConfigDto
            {
                BU_ID = fdBkConfig.BuId,
                BranchID = (int)fdBkConfig.BranchId,
                BU_Name = fdBkConfig.BuName,
                BU_Address = fdBkConfig.BuAddress ?? "",
                BU_Email_Id = fdBkConfig.BuEmailId ?? "",
                BU_Contact_Number = fdBkConfig.BuContactNumber ?? "",
                BU_Logo_URL = GetLogoUrl(fdBkConfig), // Implement a method to get the URL from the byte[] logo
                BU_ColorTheme = fdBkConfig.BuColorTheme ?? "",
                bu_font_color = fdBkConfig.BuFontColor ?? "",
                FdBk_Page_Title = fdBkConfig.FdBkPageTitle ?? "",
                FdBk_Page_SubTitle = fdBkConfig.FdBkPageSubTitle ?? "",
                FdBk_Page_Dialog = fdBkConfig.FdBkPageDialog ?? "",
                FdBk_Page_LastNote = fdBkConfig.FdBkPageLastNote ?? "",
                BU_MainImg = GetMainImageUrl(fdBkConfig),
                BU_LastImg = GetLastImageUrl(fdBkConfig)
            };

            return dto;
        }
        private string? GetLogoUrl(FbmsFeedbackConfig fdBkConfig)
        {
            if (fdBkConfig.BuLogo != null)
            {
                string logoFileName = $"{fdBkConfig.BuId}.png";
                string wwwRootPath = _configuration.GetValue<string>("WebRootPath") ?? "wwwroot";
                string logoDirectory = Path.Combine(_configuration.GetValue<string>("MEDIA_ROOT") ?? "wwwroot/media", "logos");
                string logoFilePath = Path.Combine(logoDirectory, logoFileName);
                string logoUrl = $"{_configuration.GetValue<string>("MEDIA_URL")}logos/{logoFileName}";

                // ✅ Ensure the directory exists
                if (!Directory.Exists(logoDirectory))
                {
                    Directory.CreateDirectory(logoDirectory);
                }

                // ✅ Ensure the file is saved only if it doesn’t exist
                if (!File.Exists(logoFilePath))
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(fdBkConfig.BuLogo))
                        using (Image image = Image.Load(ms))
                        {
                            image.Save(logoFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error saving logo file: {ex.Message}");
                        return null; // Return null if an error occurs
                    }
                }

                return logoUrl;
            }

            return null;
        }

        private string? GetMainImageUrl(FbmsFeedbackConfig fdBkConfig)
        {
            if (fdBkConfig.BuMainImage != null)
            {
                string Bu_MainImage = $"MainImages\\{fdBkConfig.BuId}.png";

                // Determine the actual file path
                string file_path = Path.Combine(_configuration.GetValue<String>("MEDIA_ROOT") ?? "wwwroot", Bu_MainImage);

                // Determine the URL for the frontend
                string relative_url = Path.Combine(_configuration.GetValue<String>("MEDIA_URL") ?? "wwwroot/media", Bu_MainImage).Replace('\\', '/');

                // Check if the file exists in the file system. If not, create it.
                if (!File.Exists(file_path))
                {
                    using (MemoryStream ms = new MemoryStream(fdBkConfig.BuMainImage))
                    {
                        using (Image image = Image.Load(ms))
                        {
                            image.Save(file_path);
                        }
                    }
                }
                return relative_url;
            }

            return null;

        }
        private string? GetLastImageUrl(FbmsFeedbackConfig fdBkConfig)
        {
            if (fdBkConfig.BuMainImage != null)
            {
                string Bu_LastImage = $"LastPageImages\\{fdBkConfig.BuId}.png";

                // Determine the actual file path
                string file_path = Path.Combine(_configuration.GetValue<String>("MEDIA_ROOT") ?? "wwwroot", Bu_LastImage);

                // Determine the URL for the frontend
                string relative_url = Path.Combine(_configuration.GetValue<String>("MEDIA_URL") ?? "wwwroot/media", Bu_LastImage).Replace('\\', '/');

                // Check if the file exists in the file system. If not, create it.
                if (!File.Exists(file_path))
                {
                    using (MemoryStream ms = new MemoryStream(fdBkConfig.BuLastImage ?? Array.Empty<byte>()))
                    {
                        using (Image image = Image.Load(ms))
                        {
                            image.Save(file_path);
                        }
                    }
                }
                return relative_url;
            }

            return null;

        }
    }
}
