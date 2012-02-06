using System.Collections.Generic;
using FormGenerator.Models;
using FormGenerator.Models.VisualAppearance;
using Orchard;

namespace FormGenerator.Services
{
    public interface IDisplayService : IDependency
    {
        ViewContext Display(Class dClass, dynamic shapeHelper,string propertyName);
        void Editor(Class dClass);
        void Process(Object o);
        IEnumerable<string> GetAllFieldTypes();
    }
}