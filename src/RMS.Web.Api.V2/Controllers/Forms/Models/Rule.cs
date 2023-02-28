namespace RMS.Web.Api.V2.Models
{
    public class Rule
    {
        /// <summary>
        /// Rule name, must not contain spaces.
        /// </summary>
        [Required]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Contains int values, which help to set the rule. E.G:
        /// <para/> If the rule is 'Required', then there are no conditions.
        /// <para/> If the rule is 'Max', then there must be 1 condition value to denote the max amount of characters possible in the field.
        /// <para/> If the rule is 'Between', then there are 2 condition values to establish the lower and upper boundary.
        /// </summary>
        public int[]? Conditions { get; set; }

        /// <summary>
        /// A valid Javascript conditional expression,
        /// written as a valid c# string expression which will be interpolated
        /// using the condition values. Must evaluate a value and return truthy or falsy.
        /// </summary>
        /// <example>
        /// <code>
        /// // Required rule
        /// val => val != null && val != ''
        /// 
        /// // Max X characters rule
        /// val => val.length <= {0}
        /// </code>
        /// <example>
        public string Expression { get; set; } = default!;

        /// <summary>
        /// The error message which will display if the field doesn't validate.
        /// </summary>
        public string? Error { get; set; }
    }
}
