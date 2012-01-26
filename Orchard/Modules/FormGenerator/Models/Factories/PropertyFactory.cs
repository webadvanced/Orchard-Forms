using System;
using System.Collections.Generic;
using FormGenerator.Models.Validation;
using FormGenerator.Models.VisualAppearance;
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


        public Property Create(Class dClass, string name, IEnumerable<IValidationRule> validationRules, string displayName, string displayType, string settings)
        {
            var errorMessage = "";
            if(dClass == null)
            {
                errorMessage += "Class should not be null" + Environment.NewLine;
            }
            if(string.IsNullOrEmpty(name))
            {
                errorMessage += "Name should not be empty or null";
            }
            if (string.IsNullOrEmpty(displayName))
            {
                errorMessage += "DisplayName should not be empty or null";
            }
            if (string.IsNullOrEmpty(displayType))
            {
                errorMessage +=  "Type should not be empty or null";
            }
            if(!string.IsNullOrEmpty(errorMessage))
            {
                throw new ApplicationException(errorMessage);
            }

            var displayContext = _contentManager.Create<DisplayContextPart>("DisplayContext", d =>
                                                                                              {
                                                                                                  d.Name = displayName;
                                                                                                  d.Type = displayType;
                                                                                              });

            var property = new Property
                               {
                                   Class = dClass,
                                   Name = name,
                                   ValidationRules = validationRules,
                                   DisplayContext = displayContext.Record,
                                   Settings = settings
                               };
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