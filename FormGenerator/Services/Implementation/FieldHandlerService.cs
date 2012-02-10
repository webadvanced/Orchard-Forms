using System;
using System.Collections.Generic;
using System.Linq;
using FormGenerator.Models;
using FormGenerator.VisualAppearance;

namespace FormGenerator.Services.Implementation
{
    public class FieldHandlerService : IFieldHandlerService
    {
        private readonly IEnumerable<IFieldHandler> _handlers;

        public FieldHandlerService(IEnumerable<IFieldHandler> handlers)
        {
            _handlers = handlers;
        }

        public IFieldHandler GetFieldHandler(string name)
        {
           return _handlers.FirstOrDefault(h => h.GetType().Name.Contains(name));
        }

        public IFieldHandler GetFieldHandler(Property property)
        {
            return _handlers.FirstOrDefault(h => h.GetType().Name.Contains(property.DisplayContext.Type));
        }
    }
}