using System;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace FormGenerator.Models
{
    public class DisplayContext
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        public virtual int Weight { get; set; }
    }
  
}