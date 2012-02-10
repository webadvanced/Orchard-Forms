using System;
using FormGenerator.Models;
using FormGenerator.Models.Factories;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentTypes.Services;
using Orchard.ContentTypes.ViewModels;
using Orchard.Data;

namespace FormGenerator.Services.Implementation
{
    public class DefinitionService : IDefinitionService
    {
        private readonly IRepository<DisplayContext> _displayContextRepository;
        private readonly IRepository<Property> _propertyRepository;
        private readonly IContentDefinitionService _contentDefinitionService;
        private readonly IOrchardServices _orchardServices;

        public DefinitionService(IContentDefinitionService contentDefinitionService, IOrchardServices orchardServices, IRepository<DisplayContext> displayContextRepository, IRepository<Property> propertyRepository)
        {
            _orchardServices = orchardServices;
            _propertyRepository = propertyRepository;
            _displayContextRepository = displayContextRepository;
            _contentDefinitionService = contentDefinitionService;
        }

        public Property AddPropertyToClass(Class dClass, Action<Property> initiailize)
        {
            throw new NotImplementedException();
            //var property = new PropertyFactory(_displayContextRepository,_propertyRepository).Create(dClass, initiailize);
            //_contentDefinitionService.AddFieldToPart(property.Name,"ValueGenericField","FormDefinitionPart");
            //var typeViewModel = _contentDefinitionService.GetType("Form");
            //var updateModel = new FieldUpdateModel { Settings = new ValueGenericFieldSettings { MaxLength = "25" }, FieldName = property.Name };
            //_contentDefinitionService.AlterType(typeViewModel, updateModel);

            //return property;
        }
    }
}