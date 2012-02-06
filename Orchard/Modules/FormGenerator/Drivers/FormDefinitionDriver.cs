using System;
using System.Web.Mvc;
using FormGenerator.Models;
using FormGenerator.Services;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace FormGenerator.Drivers
{
    public class FormDefinitionDriver : ContentPartDriver<FormDefinitionPart>
    {
        private readonly IDisplayService _displayService;

        public FormDefinitionDriver(IDisplayService displayService)
        {
            _displayService = displayService;
        }

        protected override DriverResult Display(FormDefinitionPart part, string displayType, dynamic shapeHelper)
        {

            return Combined(
                ContentShape("EditorTemplates_FormDefinition",
                               () =>
                               shapeHelper.Parts_FormDefinition(
                               ContentPart: part,
                               TemplateName: "EditorTemplates/FormDefinition",
                               ContentItem: part.ContentItem,
                               Prefix: Prefix
                               ))
               );
        }


        [HttpGet]
        protected override DriverResult Editor(FormDefinitionPart part, dynamic shapeHelper)
        {
            var fieldTypeList = _displayService.GetAllFieldTypes();
            return Combined(
                     ContentShape("Parts_FormDefinition",
                                    () =>
                                    shapeHelper.Parts_FormDefinition(
                                    ContentPart: part,
                                    TemplateName: "Parts/FormDefinition",
                                    ContentItem: part.ContentItem,
                                    Prefix: Prefix,
                                    FieldTypeList: fieldTypeList
                                    ))
                    );
        }
        [HttpPost]
        protected override DriverResult Editor(FormDefinitionPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            var test = ((Controller) updater).Request.Form;
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}