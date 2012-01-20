using System;
using System.Collections.Generic;

namespace FormGenerator.Models
{
    public class Object
    {
        public Object()
        {
            Created = DateTime.Now;
            Values = new List<Value>();
        }
        public bool Validate()
        {
            var result = true;
            Values.ForEach(value =>
            {
                result = result && value.Validate();
                ValidationMessage += value.ValidationMessage + Environment.NewLine;
            });
            return result;
        }
        public string ValidationMessage { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual Class Class { get; set; }
        public virtual List<Value> Values { get; set; }
    }
}