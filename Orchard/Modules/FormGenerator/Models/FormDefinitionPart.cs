using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.Core.Routable.Models;

namespace FormGenerator.Models
{
    public class FormDefinitionPart : ContentPart<Class>
    {
        public string DisplayName
        {
            get { return this.As<RoutePart>().Title; }
            set { this.As<RoutePart>().Title = value; }
        }
        public string Name { get { return Record.Name; } set { Record.Name = value; } }
        public string DefaultEmail { get { return Record.DefaultEmail; } set { Record.DefaultEmail = value; } }
        public IList<Property> Properties { get { return Record.Properties; } set { Record.Properties = value; } }
    }
}