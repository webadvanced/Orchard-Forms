using System.Collections.Generic;
using FormGenerator.Models;
using FormGenerator.Models.VisualAppearance;
using Orchard;

namespace FormGenerator.Services
{
    public interface IDisplayService : IDependency
    {
        IEnumerable<ViewContext> Display(Class dClass, dynamic shapeHelper);
        void Editor(Class dClass);
        void Process(Object o);
    }
}