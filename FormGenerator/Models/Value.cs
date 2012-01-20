using System;
using System.Linq;

namespace FormGenerator.Models
{
    public class Value
    {        
        public virtual Property Property { get; set; }
        public virtual Object Object { get; set; }
        public virtual string value { get; set; }
        public string ValidationMessage { get; set; }
        public bool Validate()
        {
            var result = true;
            Property.ValidationRules.ToList().ForEach(rule =>
                                                          {
                                                              result = result && rule.Validate(this);
                                                              ValidationMessage += rule.ValidationMessage + Environment.NewLine;
                                                          });
            return result;
        }
    }
}