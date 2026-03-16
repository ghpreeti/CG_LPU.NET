using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProjectManagementSystem.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CompareWithAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        public bool IsLessThan { get; set; }
        public bool IsGreaterThan { get; set; }

        public CompareWithAttribute(string comparisonProperty)
            => _comparisonProperty = comparisonProperty;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            PropertyInfo? property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                return new ValidationResult($"Unknown property: {_comparisonProperty}");

            var other = property.GetValue(validationContext.ObjectInstance);
            if (value == null || other == null) return ValidationResult.Success;

            if (value is IComparable comparable && other is IComparable comparableOther)
            {
                int cmp = comparable.CompareTo(comparableOther);
                if (IsLessThan && cmp >= 0) return new ValidationResult(ErrorMessage);
                if (IsGreaterThan && cmp <= 0) return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
            => value is not DateTime d || d > DateTime.Now;

        public override string FormatErrorMessage(string name)
            => $"{name} must be a future date";
    }

    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
            => value is not DateTime d || d < DateTime.Now;

        public override string FormatErrorMessage(string name)
            => $"{name} must be a past date";
    }
}
