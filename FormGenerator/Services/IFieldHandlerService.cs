using FormGenerator.Models;
using FormGenerator.VisualAppearance;
using Orchard;

namespace FormGenerator.Services
{
    public interface IFieldHandlerService : IDependency
    {
        IFieldHandler GetFieldHandler(string name);
        IFieldHandler GetFieldHandler(Property property);
    }
}