using ems_backend.Common.DefaultConstants;
using System.ComponentModel.DataAnnotations;

namespace ems_backend.Common.HandleExceptions
{
    public class HandleValidationException
    {
        public static bool ValidateEmail(string email)
        {
            var emailValidator = new EmailAddressAttribute();
            if (!emailValidator.IsValid(email))
            {
                return false;
            }
            if (email.Length > 50)
            {
                return false;
            }
            return true;
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                return false ;
            }
            return true;
        }
    }
}
