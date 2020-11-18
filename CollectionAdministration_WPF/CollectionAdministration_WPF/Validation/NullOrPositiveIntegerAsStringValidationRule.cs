using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace CollectionAdministration_WPF.Validation
{
    class NullOrPositiveIntegerAsStringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is BindingExpression expression)
            {
                object sourceItem = expression.DataItem;
                if (sourceItem != null)
                {
                    string propertyName = expression.ParentBinding != null && expression.ParentBinding.Path != null ? expression.ParentBinding.Path.Path : null;
                    object sourceValue = sourceItem.GetType().GetProperty(propertyName).GetValue(sourceItem, null);

                    if (sourceValue == null || sourceValue.ToString().Length == 0)
                    {
                        return ValidationResult.ValidResult;
                    }

                    string stringValue = sourceValue.ToString();

                    if (!int.TryParse(stringValue, out int intValue))
                    {
                        return new ValidationResult(false, Constants.Constants.POSITIVE_INT_OR_EMPTY_STRING_REQUIRED_VALIDATION_MESSAGE);
                    }

                    if (intValue < 0)
                    {
                        return new ValidationResult(false, Constants.Constants.POSITIVE_INT_OR_EMPTY_STRING_REQUIRED_VALIDATION_MESSAGE);
                    }

                    return ValidationResult.ValidResult;
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
