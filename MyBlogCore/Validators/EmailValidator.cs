using System;
using System.Net.Mail;

namespace MyBlogCore.Validators
{
    public class EmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
