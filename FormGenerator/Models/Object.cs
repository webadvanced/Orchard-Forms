using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.ContentManagement.Records;

namespace FormGenerator.Models
{
    public class Object 
    {
        public virtual int Id { get; set; }
        public Object()
        {
            Created = DateTime.Now;
            Values = new List<Value>();
        }
        public virtual bool Validate()
        {
            var result = true;
            Values.ToList().ForEach(value =>
            {
                result = result && value.Validate();
                ValidationMessage += value.ValidationMessage + Environment.NewLine;
            });
            return result;
        }
        public virtual string ValidationMessage { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual Class Class { get; set; }
        public virtual IList<Value> Values { get; set; }
    }
}