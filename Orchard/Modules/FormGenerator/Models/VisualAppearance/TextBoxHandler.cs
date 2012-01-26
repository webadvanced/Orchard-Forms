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
            if (property.DisplayContext.Type == "TextBox")
            {
                viewContext.Html += "</ br><span>" + property.DisplayContext.Name + ":</span><input teyp='text' name='" + property.Name +
                                    "'></input></ br>";
                viewContext.ShapeType = "Fields_Textbox";
                viewContext.ShapeResult = shapeHelper.Fields_Textbox(property: property);
            }
        }
    }
}