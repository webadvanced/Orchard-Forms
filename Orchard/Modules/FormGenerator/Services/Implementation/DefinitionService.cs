using System;
using FormGenerator.Field;
using FormGenerator.Field.Settings;
using FormGenerator.Models;
using FormGenerator.Models.Factories;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentTypes.Services;
using Orchard.ContentTypes.ViewModels;

namespace FormGenerator.Services.Implementation
{
    public class DefinitionService : IDefinitionService
    {
        private readonly IContentManager _contentManager;
        private readonly IContentDefinitionService _contentDefinitionService;
        private readonly IOrchardServices _orchardServices;        

        public DefinitionService(IContentManager contentManager, IContentDefinitionService contentDefinitionService, IOrchardServices orchardServices)
        {
            _contentManager = contentManager;
            _orchardServices = orchardServices;
            _contentDefinitionService = contentDefinitionService;           
        }

        public Property AddPropertyToClass(Class dClass,Action<Property> initiailize)
        {
        
            var property = new PropertyFactory(_contentManager).Create(dClass, initiailize);
            _contentDefinitionService.AddFieldToPart(property.Name,"ValueGenericField","FormDefinitionPart");
            var typeViewModel = _contentDefinitionService.GetType("Form");
            var updateModel = new FieldUpdateModel { Settings = new ValueGenericFieldSettings { MaxLength = "25" }, FieldName = property.Name };
            _contentDefinitionService.AlterType(typeViewModel, updateModel);
            
            return property;
        }
    }
}