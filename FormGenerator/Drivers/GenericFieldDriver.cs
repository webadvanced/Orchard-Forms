using System.Collections.Generic;
using System.Linq;
using FormGenerator.Models;
using FormGenerator.Models.Factories;
using FormGenerator.Models.VisualAppearance;
using FormGenerator.Services;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Data;

namespace FormGenerator.Drivers
{
    public class GenericFieldDriver : ContentFieldDriver<GenericField>
    {
        private readonly IDisplayService _displayService;
        private readonly IRepository<Property> _propertyRepository;
        private readonly IRepository<DisplayContext> _displayContextRepostiory;
        private readonly IContentManager _contentManager;

        public GenericFieldDriver(IDisplayService displayService, IRepository<Property> propertyRepository, IRepository<DisplayContext> displayContextRepostiory, IContentManager contentManager)
        {
            _displayService = displayService;
            _contentManager = contentManager;
            _displayContextRepostiory = displayContextRepostiory;
            _propertyRepository = propertyRepository;
        }

        protected override DriverResult Display(ContentPart part, GenericField field, string displayType, dynamic shapeHelper)
        {
            var dClass = ((FormPart) part).Record;
            //var property = new PropertyFactory(_contentManager).Create(dClass, "RadioButtonName1", null, "Radio Display Name1", "RadioButton", "");


            //dClass.Properties.Add(property);
            IEnumerable<ViewContext> viewContexts = _displayService.Display(dClass, shapeHelper);

            return
                Combined(
                    viewContexts.Select(
                        viewContext => ContentShape(viewContext.ShapeType, () => viewContext.ShapeResult)).ToArray());

        }
    }
}