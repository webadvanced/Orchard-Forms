using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FormGenerator.Field;
using FormGenerator.Field.Settings;
using FormGenerator.Models;
using FormGenerator.Models.Factories;
using FormGenerator.Models.VisualAppearance;
using FormGenerator.Services;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Data;
using ViewContext = FormGenerator.Models.VisualAppearance.ViewContext;

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
            var dClass = ((FormPart)part).Record;



            //var property = new PropertyFactory(_contentManager).Create(dClass, "RadioButtonName1", null, "Radio Display Name1", "RadioButton", "");


            //dClass.Properties.Add(property);
            IEnumerable<ViewContext> viewContexts = _displayService.Display(dClass, shapeHelper,field.Name);
            var t = field.PartFieldDefinition.Settings.GetModel<GenericFieldSettings>().MaxLength;
            return
                Combined(
                    viewContexts.Select(
                        viewContext => ContentShape(viewContext.ShapeType, () => viewContext.ShapeResult)).ToArray());

        }

        [HttpGet]
        protected override DriverResult Editor(ContentPart part, GenericField field, dynamic shapeHelper)
        {
            var t = field.PartFieldDefinition.Settings.GetModel<GenericFieldSettings>().MaxLength;
            var dClass = ((FormPart)part).Record;
            ViewContext viewContext = _displayService.Display(dClass, shapeHelper, field.Name);
            return Combined(ContentShape(viewContext.ShapeType, () => viewContext.ShapeResult));
        }
        [HttpPost]
        protected override DriverResult Editor(ContentPart part, GenericField field, IUpdateModel updater, dynamic shapeHelper)
        {
            var tsdf = field.PartFieldDefinition.Settings.GetModel<GenericFieldSettings>().MaxLength;
            var dClass = ((FormPart)part).Record;
            var contorller = (Controller)updater;

            foreach (var property in dClass.Properties)
            {
                var t = contorller.Request.Form[property.Name];
            }
            var settings = field.PartFieldDefinition.Settings.GetModel<GenericFieldSettings>();
            
            return Editor(part, field, shapeHelper);
        }


        private static string GetPrefix(ContentField field, ContentPart part)
        {
            // handles spaces in field names
            return (part.PartDefinition.Name + "." + field.Name)
                   .Replace(" ", "_");
        }
    }
}