namespace AnimeQSystem.Common
{
    /// <summary>
    /// A helper class for methods which are common for all areas
    /// </summary>
    public static class MiscHelper
    {
        public static async byte[] ConvertImageToBytes(IFromFile ImageFile)
        {
            byte[] ImageData;
            string imagesFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\wwwroot\images"));

            // If there is not an image, use default one
            if (ImageFile == null)
            {
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
    }
}
