using System;
using System.Linq;
using Orchard.ContentManagement.Drivers;

namespace FormGenerator.Models.VisualAppearance
{
    public class TextBoxHandler : IAppearanceHandler
    {
        public IAppearanceHandler Next
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void ProcessProperty(Object o)
        {
            throw new NotImplementedException();
        }

        public void EditorProperty(Property property, ViewContext viewContext, dynamic shapeHelper)
        {
            if (property.DisplayContext.Type == "TextBox")
            {
                viewContext.Html += "";
                viewContext.ShapeType = "EditorTemplates_Fields_Property_Textbox";
                viewContext.ShapeResult = shapeHelper.Fields_Textbox(property: property);
            }
        }

        public void DisplayProperty(Property property, ViewContext viewContext, dynamic shapeHelper)
        {
            throw new NotImplementedException();
        }


        public void ProcessValue(Object o)
        {
            throw new NotImplementedException();
        }

        public void EditorValue(Property property, ViewContext viewContext, dynamic shapeHelper)
        {
            if (property.DisplayContext.Type == "TextBox")
            {
                viewContext.Html += "";
                viewContext.ShapeType = "EditorTemplates_Fields_Value_Textbox";
                viewContext.ShapeResult = shapeHelper.Fields_Textbox(property: property);
            }
        }

        public void DisplayValue(Property property, ViewContext viewContext, dynamic shapeHelper)
        {
            if (property.DisplayContext.Type == "TextBox")
            {
                viewContext.Html += "</ br><span>" + property.DisplayContext.Name + ":</span><input teyp='text' name='" + property.Name +
                                    "'></input></ br>";
                viewContext.ShapeType = "EditorTemplates_Fields_Value_Textbox";
                viewContext.ShapeResult = shapeHelper.Fields_Textbox(property: property);
            }
        }
    }
}