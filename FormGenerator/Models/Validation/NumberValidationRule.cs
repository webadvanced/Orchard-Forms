using System;

namespace FormGenerator.Models.Validation
{
    public class NumberValidationRule : IValidationRule
    {
        public bool Validate(Value value)
        {            
            double res;
            if(Double.TryParse(value.value,out res))
            {
                return true;
            }
            else
            {
                ValidationMessage = "Value should be number";
                return false;
            }
        }

        public string ValidationMessage { get; private set; }
    }
}