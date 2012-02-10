 using System;
using System.Linq;
using Orchard.ContentManagement.Records;

namespace FormGenerator.Models
{
    public class Value 
    {
        public virtual int Id { get; set; }
        public virtual Property Property { get; set; }
        public virtual Object Object { get; set; }
        public virtual string value { get; set; }
        public virtual string ValidationMessage { get; set; }
        public virtual bool Validate()
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