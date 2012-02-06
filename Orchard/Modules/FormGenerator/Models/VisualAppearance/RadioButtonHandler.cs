using System;
using System.Linq;

namespace FormGenerator.Models.VisualAppearance
{
    public class RadioButtonHandler : IAppearanceHandler
    {
        public IAppearanceHandler Next
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void ProcessValue(Object o)
        {
            throw new NotImplementedException();
        }

        public void EditorValue(Property property, ViewContext viewContext, dynamic shapeHelper)
        {
            throw new NotImplementedException();
        }

        public void EditorProperty(Property property, ViewContext viewContext, dynamic shapeHelper)
        {
            throw new NotImplementedException();
        }

        public void DisplayProperty(Property property, ViewContext viewContext, dynamic shapeHelper)
        {
            throw new NotImplementedException();
        }

        public void DisplayValue(Property property, ViewContext viewContext, dynamic shapeHelper)
        {         
                if (property.DisplayContext.Type == "RadioButton")
                {
                    viewContext.Html += "";
                    viewContext.ShapeType = "EditorTemplates_Fields_Value_RadioButton";
                    viewContext.ShapeResult = shapeHelper.Fields_RadioButton(property: property);
                }     
        }

        public void ProcessProperty(Object o)
        {
            throw new NotImplementedException();
        }
    }
}