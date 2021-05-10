using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace CollectionAdministration_WPF.Validation
{
    public class NullOrPositiveIntegerAsStringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!(value is BindingExpression expression)) 
                return ValidationResult.ValidResult;
            
            var sourceItem = expression.DataItem;

            if (sourceItem == null)
                return ValidationResult.ValidResult;
            
            var propertyName = expression.ParentBinding is {Path: { }} ? expression.ParentBinding.Path.Path : null;
            var sourceValue = sourceItem.GetType().GetProperty(propertyName)?.GetValue(sourceItem, null);

            if (sourceValue == null)
                return ValidationResult.ValidResult;

            var stringValue = sourceValue.ToString();

            if (!int.TryParse(stringValue, out var intValue) || sourceValue.ToString().Length == 0 || intValue < 0)
                return new ValidationResult(false, Constants.Constants.POSITIVE_INT_OR_EMPTY_STRING_REQUIRED_VALIDATION_MESSAGE);

            return ValidationResult.ValidResult;

        }
    }
}
