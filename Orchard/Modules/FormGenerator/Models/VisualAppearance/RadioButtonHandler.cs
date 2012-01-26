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

        public void Process(Object o)
        {
            throw new NotImplementedException();
        }

        public void Editor(Class dClass, ViewContext viewContext, dynamic shapeHelper)
        {
            throw new NotImplementedException();
        }

        public void Display(Property property, ViewContext viewContext, dynamic shapeHelper)
        {         
                if (property.DisplayContext.Type == "RadioButton")
                {
                    viewContext.Html += "";
                    viewContext.ShapeType = "Fields_RadioButton";
                    viewContext.ShapeResult = shapeHelper.Fields_RadioButton(property: property);
                }     
        }
    }
}