using System;
using System.Web.Mvc;
using FormGenerator.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace FormGenerator.Drivers
{
    public class FormDriver : ContentPartDriver<FormPart>
    {
        protected override DriverResult Display(FormPart part, string displayType, dynamic shapeHelper)
        {
            return Combined(
                ContentShape("Parts_Form",
                               () =>
                               shapeHelper.Parts_Form(
                               ContentPart: part,
                               TemplateName: "Parts/Form",
                               ContentItem: part.ContentItem,
                               Prefix: Prefix
                               ))
               );
        }


        [HttpGet]
        protected override DriverResult Editor(FormPart part, dynamic shapeHelper)
        {
            return Combined(
                     ContentShape("Parts_Form",
                                    () =>
                                    shapeHelper.Parts_Form(
                                    ContentPart: part,
                                    TemplateName: "Parts/Form",
                                    ContentItem: part.ContentItem,
                                    Prefix: Prefix
                                    ))
                    );
        }
        [HttpPost]
        protected override DriverResult Editor(FormPart part, IUpdateModel updater, dynamic shapeHelper)
        {
           
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}