using System;
using FormGenerator.Models;
using FormGenerator.Models.Factories;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentTypes.Services;

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
            _contentDefinitionService.AddFieldToPart(property.Name,"GenericField","FormPart");
            return property;
        }
    }
}