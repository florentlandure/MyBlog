using System;

namespace MyBlogCore.Utils
{
    class ValidationUtils
    {
        public static void ValidateEmptyArgument(string str, string message)
        {
            if (str.Trim().Length == 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
