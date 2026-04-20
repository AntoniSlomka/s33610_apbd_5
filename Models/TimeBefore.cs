using System.ComponentModel.DataAnnotations;

namespace Apbd5.Models
{
    public class TimeBefore(string otherPropertyName) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            var otherProperty = context.ObjectType.GetProperty(otherPropertyName);
            if (otherProperty == null)
                return new ValidationResult($"Unknown property: {otherPropertyName}");

            var otherValue = otherProperty.GetValue(context.ObjectInstance);

            if (value is TimeOnly thisTime && otherValue is TimeOnly otherTime)
            {
                if (thisTime >= otherTime)
                    return new ValidationResult(
                        $"{context.DisplayName} must be before {otherPropertyName}.",
                        new[] { context.MemberName! }
                    );
            }

            return ValidationResult.Success;
        }
    }
}
