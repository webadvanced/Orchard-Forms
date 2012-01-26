using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FormGenerator.Models.Validation;
using FormGenerator.Models.VisualAppearance;
using FormGenerator.Models.VisualAppearance;
using Orchard.ContentManagement;
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
        public virtual DisplayContext DisplayContext { get; set; }
        
        public virtual IEnumerable<IValidationRule> ValidationRules { get; set; }

        public virtual string Settings { get; set; }
    }

    public class PropertyPart : ContentPart<Property>
    {
        public string Name { get { return Record.Name; } set { Record.Name = value; } }
        public Class Class { get { return Record.Class; } set { Record.Class = value; } }
        public DisplayContext DisplayContext { get { return Record.DisplayContext; } set { Record.DisplayContext = value; } }

        public IEnumerable<IValidationRule> ValidationRules { get { return Record.ValidationRules; } set { Record.ValidationRules = value; } }

        public string Settings { get { return Record.Settings; } set { Record.Settings = value; } }
    }
}