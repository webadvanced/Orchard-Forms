using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace FormGenerator.Models
{
    public class DisplayContext : ContentPartRecord
    {
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }    
    }

    public class DisplayContextPart : ContentPart<DisplayContext>
    {
        public string Name { get { return Record.Name; } set { Record.Name = value; } }
        public string Type { get { return Record.Type; } set { Record.Type = value; } }    
    }
}