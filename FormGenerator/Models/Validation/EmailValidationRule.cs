using System;

namespace FormGenerator.Models.Validation
{
    public class EmailValidationRule : IValidationRule
    {
        public bool Validate(Value value)
        {
            throw new NotImplementedException();
        }

        public string ValidationMessage
        {
            get { throw new NotImplementedException(); }
        }
    }
}