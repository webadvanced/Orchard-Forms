using System;
using FormGenerator.Models;
using FormGenerator.ViewModel;
using Object = FormGenerator.Models.Object;

namespace FormGenerator.VisualAppearance
{
    public class RadioButtonHandler : IFieldHandler
    {
        public string ViewAddress
        {
            get { throw new NotImplementedException(); }
        }

        public PropertyViewModel ViewModel
        {
            get { throw new NotImplementedException(); }
        }

        public void DisplayProperty(Property property, ViewContext viewContext, dynamic shapeHelper, int index)
        {
            throw new NotImplementedException();
        }

        public void AddViewModel(FormDefinitionViewModel formDefinitionViewModel, Property property, int index)
        {
            throw new NotImplementedException();
        }
    }
}