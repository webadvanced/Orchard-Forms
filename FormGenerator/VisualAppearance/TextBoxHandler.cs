using System;
using FormGenerator.Models;
using FormGenerator.ViewModel;
using FormGenerator.ViewModel.PropertyViewModels;
using Object = FormGenerator.Models.Object;

namespace FormGenerator.VisualAppearance
{
    public class TextBoxHandler : IFieldHandler
    {
        public string ViewAddress
        {
             get { return @"EditorTemplates\Property\Textbox"; } 
        }

        public PropertyViewModel ViewModel
        {
            get
            {
                return new TextboxViewModel()
                           {
                               Type = "TextBoxHandler",
                           };
            }
        }

        public void DisplayProperty(Property property, ViewContext viewContext, dynamic shapeHelper, int index)
        {
            viewContext.ShapeType = "Property_Textbox";
            viewContext.ShapeResult = shapeHelper.EditorTemplate(
                TemplateName: "Property/Textbox",
                Model: new TextboxViewModel(index, property),
                Prefix: ""
            );
        }

        public void AddViewModel(FormDefinitionViewModel formDefinitionViewModel, Property property, int index)
        {
            formDefinitionViewModel.Textboxes.Add(new TextboxViewModel(index,property));
        }
    }
}