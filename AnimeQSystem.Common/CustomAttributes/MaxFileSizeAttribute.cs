using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AnimeQSystem.Common.CustomAttributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public MaxFileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value is IFormFile file)
            {
                return file.Length <= _maxSize;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The file size exceeds the maximum allowed size of {Math.Round(_maxSize / 1024m / 1024)} MB.";
        }
    }
}
