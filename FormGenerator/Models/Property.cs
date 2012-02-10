using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FormGenerator.Models.Validation;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace FormGenerator.Models
{
    public class Property 
    {
        public Property()
        {
            
        }

        public virtual int Id { get; set; }
        public Property(string name, Class dClass, DisplayContext displayContext)
        {
            Name = name;            
            Class = dClass;            
        }
        public virtual string Name { get; set; }
        public virtual Class Class { get; set; }        
        public virtual DisplayContext DisplayContext { get; set; }
        
        public virtual IEnumerable<IValidationRule> ValidationRules { get; set; }

        public virtual string Settings { get; set; }
    }

}