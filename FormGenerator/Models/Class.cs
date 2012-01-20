using System;
using System.Collections.Generic;
using Orchard.ContentManagement.Records;

namespace FormGenerator.Models
{
    public class Class : ContentPartRecord
    {
        public Class()
        {
            Properties = new List<Property>();
        }
        public virtual string Name { get; set; }
        public virtual string DefaultEmail { get; set; }
        public virtual List<Property> Properties { get; set; }      
    }
}