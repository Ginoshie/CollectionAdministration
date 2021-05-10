using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;

namespace CollectionAdministration_WPF.Validation
{
    public class NullOrPositiveDoubleAsStringValidationRule : ValidationRule
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

            if (!double.TryParse(stringValue, out double doubleValue) || 
                Regex.Matches(stringValue, ",").Count > 1 ||
                doubleValue < 0 ||
                sourceValue.ToString().Length == 0)
                return new ValidationResult(false, Constants.Constants.POSITIVE_DOUBLE_OR_EMPTY_STRING_REQUIRED_VALIDATION_MESSAGE);

            return ValidationResult.ValidResult;
        }
    }
}
