using FormGenerator.Models;
using FormGenerator.ViewModel;
using Orchard;
using Object = FormGenerator.Models.Object;

namespace FormGenerator.VisualAppearance
{
    public interface IFieldHandler : IDependency
    {
        string ViewAddress { get; }
        PropertyViewModel ViewModel { get; }
        void DisplayProperty(Property property, ViewContext viewContext, dynamic shapeHelper,int index);
        void AddViewModel(FormDefinitionViewModel formDefinitionViewModel, Property property, int index);
    }
}