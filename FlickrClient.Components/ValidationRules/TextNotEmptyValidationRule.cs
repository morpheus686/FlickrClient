using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlickrClient.Components.ValidationRules
{
    public class TextNotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string validationCode = (string)value;

            if (String.IsNullOrWhiteSpace(validationCode))
            {
                return new ValidationResult(false, "Validation code must not be empty!");                
            }

            return ValidationResult.ValidResult;
        }
    }
}
