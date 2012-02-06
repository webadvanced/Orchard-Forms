using System.Collections.Generic;
using FormGenerator.Models.VisualAppearance;
using Orchard.ContentManagement;

namespace FormGenerator.Models
{
    public class FormDefinitionPart : ContentPart<Class>
    {
        public string Name { get { return Record.Name; } set { Record.Name = value; } }
        public string DefaultEmail { get { return Record.DefaultEmail; } set { Record.DefaultEmail = value; } }        
    }
}