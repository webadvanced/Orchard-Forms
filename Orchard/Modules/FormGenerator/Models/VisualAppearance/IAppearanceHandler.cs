using System;
using Orchard.ContentManagement.Drivers;

namespace FormGenerator.Models.VisualAppearance
{
    public interface IAppearanceHandler
    {        
        void ProcessValue(Object o);
        void EditorValue(Property property, ViewContext viewContext, dynamic shapeHelper);
        void DisplayValue(Property property, ViewContext viewContext, dynamic shapeHelper);

        void ProcessProperty(Object o);
        void EditorProperty(Property property, ViewContext viewContext, dynamic shapeHelper);
        void DisplayProperty(Property property, ViewContext viewContext, dynamic shapeHelper);
    }
}