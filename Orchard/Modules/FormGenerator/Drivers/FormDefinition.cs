using System;
using System.Web.Mvc;
using FormGenerator.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace FormGenerator.Drivers
{
    public class FormDefinition : ContentPartDriver<FormDefinitionPart>
    {
        protected override DriverResult Display(FormDefinitionPart part, string displayType, dynamic shapeHelper)
        {
            return Combined(
                ContentShape("Parts_FormDefinition",
                               () =>
                               shapeHelper.Parts_FormDefinition(
                               ContentPart: part,
                               TemplateName: "Parts/FormDefinition",
                               ContentItem: part.ContentItem,
                               Prefix: Prefix
                               ))
               );
        }


        [HttpGet]
        protected override DriverResult Editor(FormDefinitionPart part, dynamic shapeHelper)
        {
            return Combined(
                     ContentShape("Parts_FormDefinition",
                                    () =>
                                    shapeHelper.Parts_FormDefinition(
                                    ContentPart: part,
                                    TemplateName: "Parts/FormDefinition",
                                    ContentItem: part.ContentItem,
                                    Prefix: Prefix
                                    ))
                    );
        }
        [HttpPost]
        protected override DriverResult Editor(FormDefinitionPart part, IUpdateModel updater, dynamic shapeHelper)
        {
           
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}