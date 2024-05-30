using System.ComponentModel.DataAnnotations;

namespace TI_Devops_2024_DemoAspMvc.Validators
{
    public class ISBNValidationAttribute : ValidationAttribute
    {
        public ISBNValidationAttribute()
        {
            ErrorMessage = "ISBN must contains 11 or 13 characters";
        }

        public override bool IsValid(object? value)
        {
            if(value == null)
            {
                return true;
            }
            if (value is string isbn) 
            {
                return isbn.Length == 11 || isbn.Length == 13;
            }
            return false;

        }
    }
}
