using System;
using System.Collections.Generic;
using FormGenerator.Models.Validation;
using FormGenerator.Models.VisualAppearance;
using FormGenerator.Models.VisualAppearance;
using Orchard.ContentManagement.Records;

namespace FormGenerator.Models
{
    public class Property : ContentPartRecord
    {
        public Property()
        {
            
        }

        public Property(string name, Class dClass, DisplayContext displayContext)
        {
            Name = name;            
            Class = dClass;            
        }
        public virtual string Name { get; set; }
        public virtual Class Class { get; set; }        
        public DisplayContext DisplayContext { get; set; }
        public IEnumerable<IValidationRule> ValidationRules { get; set; }

        public string Settings { get; set; }
    }
}