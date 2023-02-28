namespace RMS.Web.Api.V2.Utilities
{
    public class MaskValidation : ValidationAttribute
    {
        static string QuasarCharacters = "#SNAaXx";
        static string SpecialCharacters = "() - _/*+!@$%^&=:;\\ ";

        /// <summary>
        /// Which characters are allowed. it's all the quasar mask characters + special characters.
        /// Quasar characters found here https://quasar.dev/vue-components/input#mask.
        /// </summary>
        static string AllowedCharacters = QuasarCharacters + SpecialCharacters;

        new string ErrorMessage => $"The mask is incorrectly formatted and/or containts unsupported characters. Only {AllowedCharacters} are allowed.";
       
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var Mask = (string)validationContext.ObjectInstance;

            return (Mask.All(character => AllowedCharacters.Contains(character))) ?
                ValidationResult.Success :
                new ValidationResult(ErrorMessage);
        }
    }
}
