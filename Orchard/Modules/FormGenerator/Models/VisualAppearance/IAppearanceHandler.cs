using System;
using Orchard.ContentManagement.Drivers;

namespace FormGenerator.Models.VisualAppearance
{
    public interface IAppearanceHandler
    {
        IAppearanceHandler Next { get; set; }
        void Process(Object o);
        void Editor(Class dClass, ViewContext viewContext, dynamic shapeHelper);
        void Display(Property property, ViewContext viewContext, dynamic shapeHelper);
    }
}