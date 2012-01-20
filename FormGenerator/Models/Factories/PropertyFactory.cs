using System;
using System.Collections.Generic;
using FormGenerator.Models.Validation;
using FormGenerator.Models.VisualAppearance;

namespace FormGenerator.Models.Factories
{
    public static class PropertyFactory
    {
        public static Property Create(Class dClass, string name, IEnumerable<IValidationRule> validationRules, string displayName, string type, string settings)
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
            if (string.IsNullOrEmpty(type))
            {
                errorMessage +=  "Type should not be empty or null";
            }
            if(!string.IsNullOrEmpty(errorMessage))
            {
                throw new ApplicationException(errorMessage);
            }
            var property = new Property();
            property.Class = dClass;
            property.Name = name;
            property.ValidationRules = validationRules;
            var displayContext = new DisplayContext {Name = displayName, Type = type};
            property.DisplayContext = displayContext;
            property.Settings = settings;
            return property;
        }
    }
}