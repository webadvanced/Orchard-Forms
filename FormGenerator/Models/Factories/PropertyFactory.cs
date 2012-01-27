using System;
using System.Collections.Generic;
using FormGenerator.Models.Validation;
using FormGenerator.Models.VisualAppearance;
using FormGenerator.Services;
using Orchard.ContentManagement;

namespace FormGenerator.Models.Factories
{
    public class PropertyFactory
    {
        private readonly IContentManager _contentManager;

        public PropertyFactory(IContentManager contentManager)
        {
            _contentManager = contentManager;       
        }


        public Property Create(Class dClass,Action<Property> initialize)
        {
            var property = new Property();
            initialize(property);
            var errorMessage = "";
            if(dClass == null)
            {
                errorMessage += "Class should not be null" + Environment.NewLine;
            }
            if(string.IsNullOrEmpty(property.Name))
            {
                errorMessage += "Name should not be empty or null";
            }
            if (string.IsNullOrEmpty(property.DisplayContext.Name))
            {
                errorMessage += "DisplayName should not be empty or null";
            }
            if (string.IsNullOrEmpty(property.DisplayContext.Type))
            {
                errorMessage +=  "Type should not be empty or null";
            }
            if(!string.IsNullOrEmpty(errorMessage))
            {
                throw new ApplicationException(errorMessage);
            }

            var displayContext = _contentManager.Create<DisplayContextPart>("DisplayContext", d =>
                                                                                              {
                                                                                                  d.Name = property.DisplayContext.Name;
                                                                                                  d.Type = property.DisplayContext.Type;
                                                                                              });

            property.Class = dClass;
            property.DisplayContext = displayContext.Record;                                   
                               
            var propertyPart = _contentManager.Create<PropertyPart>("Property", p =>
            {
                p.Class = property.Class;
                p.DisplayContext = property.DisplayContext;
                p.Name = property.Name;
                p.Settings = property.Settings;
            });
            _contentManager.Flush();             
            return propertyPart.Record;
        }
    }
}