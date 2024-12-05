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
            if (value is byte[] fileBytes)
            {
                return fileBytes.Length <= _maxSize;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The file size exceeds the maximum allowed size of {_maxSize} bytes.";
        }
    }
}
