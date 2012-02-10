using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using FormGenerator.Models.Validation;
using FormGenerator.Services;
using Orchard.ContentManagement;
using Orchard.Data;

namespace FormGenerator.Models.Factories
{
    public class PropertyFactory
    {
        private readonly IRepository<DisplayContext> _displayContextRepository;
        private readonly IRepository<Property> _propertyRepository;
        public PropertyFactory(IRepository<DisplayContext> displayContextRepository, IRepository<Property> propertyRepository)
        {
            _displayContextRepository = displayContextRepository;
            _propertyRepository = propertyRepository;
        }


        public Property Create(Class dClass, Action<Property> initialize)
        {
            var property = new Property();
            initialize(property);
            var errorMessage = "";
            if (dClass == null)
            {
                errorMessage += "Class should not be null" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(property.Name))
            {
                errorMessage += "Name should not be empty or null";
            }
            if (string.IsNullOrEmpty(property.DisplayContext.Name))
            {
                errorMessage += "DisplayName should not be empty or null";
            }
            if (string.IsNullOrEmpty(property.DisplayContext.Type))
            {
                errorMessage += "Type should not be empty or null";
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new ApplicationException(errorMessage);
            }


            _displayContextRepository.Create(property.DisplayContext);

            property.Class = dClass;
            _propertyRepository.Create(property);

            return property;
        }
    }
}