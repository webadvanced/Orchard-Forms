using System;
using System.Collections.Generic;
using Orchard.ContentManagement;

namespace FormGenerator.Models
{
    public class FormPart : ContentPart<Object>
    {
        public string ValidationMessage { get { return Record.ValidationMessage; } set { Record.ValidationMessage = value; } }
        public DateTime Created { get { return Record.Created; } set { Record.Created = value; } }
        public Class Class { get { return Record.Class; } set { Record.Class = value; } }
        public IList<Value> Values { get { return Record.Values; } set { Record.Values = value; } }
    }
}