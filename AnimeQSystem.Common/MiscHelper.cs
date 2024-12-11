using Microsoft.AspNetCore.Http;

namespace AnimeQSystem.Common
{
    /// <summary>
    /// A helper class for methods which are common for all areas
    /// </summary>
    public static class MiscHelper
    {
        public static async Task<byte[]> ConvertOrGetDefaultImage(IFormFile? ImageFile, string type)
        {
            byte[] ImageData;
            string imagesFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\wwwroot\images"));

            // If there is not an image, use default one
            if (ImageFile == null)
            {
                switch (type.ToLower())
                {
                    case "user": ImageData = File.ReadAllBytes(Path.Combine(imagesFolder, "users", "defaultuser.jpg")); break;
                    case "quiz": ImageData = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "defaultquiz.jpg")); break;
                }

                ImageData = File.ReadAllBytes(Path.Combine(imagesFolder, "users", "defaultuser.jpg"));
            }
            else
            {
                // Convert the image to byte[]
                using (var memoryStream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(memoryStream);
                    ImageData = memoryStream.ToArray(); // Convert to byte[]
                }
            }

            return ImageData;
        }

        public static string GetTimeElapsed(DateTime startDate)
        {
            // Calculate the time difference between the current time and the start date
            TimeSpan timeElapsed = DateTime.Now - startDate;

            // Check for minutes
            if (timeElapsed.TotalMinutes < 60)
            {
                return $"{(int)timeElapsed.TotalMinutes} minutes";
            }
            // Check for hours
            else if (timeElapsed.TotalHours < 24)
            {
                return $"{(int)timeElapsed.TotalHours} hours";
            }
            // Check for days
            else
            {
                return $"{(int)timeElapsed.TotalDays} days";
            }
        }
    }
}
