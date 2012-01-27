using System;
using FormGenerator.Models;
using Orchard;

namespace FormGenerator.Services
{
    public interface IDefinitionService: IDependency
    {
        Property AddPropertyToClass(Class dClass,Action<Property> initiailize);
    }
}