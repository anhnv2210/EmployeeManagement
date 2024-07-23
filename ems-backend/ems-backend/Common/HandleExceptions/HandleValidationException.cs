using ems_backend.Common.DefaultConstants;
using System.ComponentModel.DataAnnotations;

namespace ems_backend.Common.HandleExceptions
{
    public class HandleValidationException
    {
        public static void ValidateEmail(string email)
        {
            var emailValidator = new EmailAddressAttribute();
            if (!emailValidator.IsValid(email))
            {
                throw new ValidationException(Constants.ExceptionMessage.INVALID_EMAIL);
            }
            if (email.Length > 50)
            {
                throw new ValidationException("Độ dài email không dài quá 50 ký tự");
            }

        }

        public static void ValidatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                throw new ValidationException("Số điện thoại phải đủ 10 ký tự");
            }
        }
        public static void ValidateName(string name)
        {
            if (name.Length > 50)
            {
                throw new ValidationException("Độ dài tên không dài quá 50 ký tự");
            }
        }
    }
}
